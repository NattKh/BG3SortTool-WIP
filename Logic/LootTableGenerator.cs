﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using BG3LootTableGenerator.DataStructures;  // Remember to import your data structures.
// ... (other using directives)

public class LootTableGenerator
{
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

    // Step 3: Data Processing
    private void ProcessParsedData()
    {
        foreach ((string k, ItemEntry v) in _entries)
        {
            // ... (logic to process data based on inheritance and other conditions)
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

        List<string> generatedTreasureTxt = new() { "new treasuretable \"TUT_Chest_Potions\"\nCanMerge 1" };
        generatedTreasureTxt.AddRange(armourStatNames.Select(x => $"new subtable \"1,1\"\nobject category \"I_{x}\",1,0,0,0,0,0,0,0"));

        File.WriteAllLines(Path.Combine(destDir, "Armour.txt"), generatedArmourTxt);
        File.WriteAllLines(Path.Combine(destDir, "TreasureTable.txt"), generatedTreasureTxt);
    }
}

