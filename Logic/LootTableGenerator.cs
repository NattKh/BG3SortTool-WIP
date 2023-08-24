using BG3LootTableGenerator.DataStructures;  // Remember to import your data structures.
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
// ... (other using directives)

public class LootTableGenerator
{
    public record TraderCharacter(string? TraderName, string TraderId, IEnumerable<string> TraderTreasureTables);
    public record TraderLevel(string LevelName, string LevelId, IEnumerable<TraderCharacter> Traders);

    private Dictionary<string, ItemEntry> _entries = new();
    private Dictionary<string, string> _localization = new();

    public void Generate(string sourceDir, string destDir)
    {
        ParseXMLFiles(sourceDir);
        ProcessParsedData();
        WriteProcessedData(destDir);
    }

    // Existing helper method
    private IEnumerable<string> GetAllRootTemplates(string dir)
    {
        return Directory
            .EnumerateFiles(Path.Combine(dir), "*.lsx", SearchOption.AllDirectories)
            .Where(x => Path.GetDirectoryName(x)!.EndsWith("RootTemplates"))
            .Select(x => x.Replace('\\', '/'));
    }

    // Step 2: XML Parsing
    private void ParseXMLFiles(string sourceDir)
    {
        foreach (XElement elem in XDocument.Load(Path.Combine(sourceDir, "English/Localization/English/english.xml")).XPathSelectElements("contentList/content"))
        {
            _localization[elem.Attribute("contentuid")!.Value] = elem.Value;
        }

        List<string> files = GetAllRootTemplates(Path.Combine(sourceDir, "Shared/Public/Shared"))
            .Concat(GetAllRootTemplates(Path.Combine(sourceDir, "Shared/Public/SharedDev")))
            .Concat(GetAllRootTemplates(Path.Combine(sourceDir, "Gustav/Public/Gustav")))
            .Concat(GetAllRootTemplates(Path.Combine(sourceDir, "Gustav/Public/GustavDev")))
            .ToList();

        foreach (string filePath in files)
        {
            string relativeFilePath = filePath.Replace(sourceDir, "").TrimStart('/');
            IEnumerable<XElement> nodes = XDocument.Load(filePath).Root!.XPathSelectElements("region[@id = 'Templates']/node/children/node[@id = 'GameObjects'][attribute[@id='Type' and @value='item']]");

            //Populate _entries Dictionary Logic loop code

            foreach (XElement node in nodes)
            {
                string? GetAttribute(string id, string name) => node.XPathSelectElement($"attribute[@id='{id}']")?.Attribute(name)?.Value;
                string? GetAttributeValue(string id) => GetAttribute(id, "value");
                string? GetAttributeHandle(string id) => GetAttribute(id, "handle");

                string? mapKey = GetAttributeValue("MapKey");
                string? name = GetAttributeValue("Name");

                if (string.IsNullOrEmpty(mapKey) || string.IsNullOrEmpty(name))
                {
                    Console.WriteLine($"Error in {filePath}");
                    continue;
                }

                string? parent = GetAttributeValue("ParentTemplateId");
                string? displayName = GetAttributeHandle("DisplayName");
                if (displayName != null) _localization.TryGetValue(displayName, out displayName);

                string? technicalDescription = GetAttributeHandle("TechnicalDescription");
                if (technicalDescription != null) _localization.TryGetValue(technicalDescription, out technicalDescription);

                string? description = GetAttributeHandle("Description");
                if (description != null) _localization.TryGetValue(description, out description);

                ItemEntry entry = new(
                    Name: name,
                    Inheritance: null,
                    MapKey: mapKey,
                    Path: relativeFilePath,
                    Data: new(
                        ParentTemplateId: GetAttributeValue("ParentTemplateId"),
                        VisualTemplateId: GetAttributeValue("VisualTemplate"),
                        Stats: GetAttributeValue("Stats"),
                        Icon: GetAttributeValue("Icon")),
                    Localization: new(
                        DisplayName: displayName,
                        TechnicalDescription: technicalDescription,
                        Description: description));

                _entries[mapKey] = entry;
            }
        }
    }

    // Step 3: Data Processing logic
    private void ProcessParsedData()
    {
        foreach ((string k, ItemEntry v) in _entries)
        {
            string currentMapKey = k;
            string? currentParentMapKey = v.Data.ParentTemplateId;
            List<string> inheritance = new() { _entries[k].Name };

            if (!string.IsNullOrWhiteSpace(currentParentMapKey) && currentMapKey != currentParentMapKey)
            {
                do
                {
                    _entries.TryGetValue(currentParentMapKey, out ItemEntry? currentParent);
                    if (currentParent == null)
                    {
                        inheritance.Add(currentParentMapKey);
                        break;
                    }

                    currentMapKey = currentParentMapKey;
                    currentParentMapKey = currentParent.Data.ParentTemplateId;
                    inheritance.Add(currentParent.Name);

                } while (!string.IsNullOrWhiteSpace(currentParentMapKey) && currentMapKey != currentParentMapKey);

                if (inheritance.Count > 1)
                {
                    inheritance.Reverse();
                    _entries[k] = _entries[k] with { Inheritance = string.Join(':', inheritance) };
                }
            }
        }
    }
    // Step 4: File Writing

    private void WriteProcessedData(string destDir)
    {
        File.WriteAllText(
            Path.Combine(destDir, "items.json"),
            JsonSerializer.Serialize(_entries.Values, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            })
        );

        // ... (additional logic to generate armor and treasure table data and write to separate files)
        IEnumerable<ItemEntry> armours = _entries.Values.Where(x => x.InheritsFrom("BASE_ARMOR"));
        IEnumerable<ItemEntry> armoursWithStats = armours.Where(x => !string.IsNullOrWhiteSpace(x.Data.Stats));
        IEnumerable<ItemEntry> armoursWithoutStats = armours.Except(armoursWithStats);

        List<string> armourStatNames = armoursWithStats.Select(x => x.Data.Stats!).ToList();
        List<string> generatedArmourTxt = new();

        foreach (ItemEntry armour in armoursWithoutStats)
        {
            string statsName = $"LIA_GENERATED_{armour.Name}";
            string? inheritedStats = armour.GetStats(_entries.Values);

            if (!string.IsNullOrWhiteSpace(inheritedStats))
            {
                generatedArmourTxt.Add(
                    $"new entry \"{statsName}\"\n" +
                    $"type \"Armor\"\n" +
                    $"using \"{armour.GetStats(_entries.Values)}\"\n" +
                    $"data \"RootTemplate\" \"{armour.MapKey}\"\n" +
                    $"data \"Unique\" \"0\"\n");
                armourStatNames.Add(statsName);
            }
        }
        // traders write level logic 
        List<string> generatedTreasureTxt = new() { "new treasuretable \"TUT_Chest_Potions\"\nCanMerge 1" };
        generatedTreasureTxt.AddRange(armourStatNames.Select(x => $"new subtable \"1,1\"\nobject category \"I_{x}\",1,0,0,0,0,0,0,0"));

        File.WriteAllLines(Path.Combine(destDir, "Armour.txt"), generatedArmourTxt);
        File.WriteAllLines(Path.Combine(destDir, "TreasureTable.txt"), generatedTreasureTxt);
    }
    public void WriteLevels(Levels levels, string destDir)
    {
        JsonSerializerOptions opts = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
        };

        string path = Path.Combine(destDir, "levels.json");
        File.WriteAllText(path, JsonSerializer.Serialize(levels.Entries.Values, opts));
    }

    public void WriteTraders(Levels levels, string destDir)
    {
        JsonSerializerOptions opts = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
        };

        string path = Path.Combine(destDir, "traders.json");
        var traderData = levels.Entries.Values
            .Select(l => new TraderLevel(
                LevelName: l.Name,
                LevelId: l.Id,
                Traders: l.Characters
                    .Where(c => c.Tags?.Contains("TRADER") ?? false)
                    .Select(c => new TraderCharacter(
                        TraderName: c.DisplayName,
                        TraderId: c.Name,
                        TraderTreasureTables: c.TradeTreasureTables!))))
            .Where(l => l.Traders.Any());

        File.WriteAllText(path, JsonSerializer.Serialize(traderData, opts));
    }
}
