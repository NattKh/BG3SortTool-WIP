using System;
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

            foreach (XElement node in nodes)
            {
                // ... (logic to extract attributes and populate _entries dictionary)
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
    }
}

