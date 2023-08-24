using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;
using System.IO;

namespace BG3LootTableGenerator.DataStructures
{
    public class Tags
    {
        public IReadOnlyDictionary<string, string> Entries => _entries;
        private readonly Dictionary<string, string> _entries = new();

        public Tags(IEnumerable<string> loadOrder)
        {
            foreach (string filePath in loadOrder
                .SelectMany(x => Util.GetAllTemplates(Path.Combine(Config.SourceDir, x, "Tags")))
                .Progress("Loading tags"))
            {
                LoadFrom(filePath);
            }
        }

        public void LoadFrom(string path)
        {
            IEnumerable<XElement> elements = XDocument.Load(path).Root!.XPathSelectElements("region[@id = 'Tags']/node[@id = 'Tags']");
            foreach (XElement element in elements)
            {
                string? GetAttributeValue(string id) => element.XPathSelectElement($"attribute[@id='{id}']")?.Attribute("value")?.Value;
                _entries[GetAttributeValue("UUID")!] = GetAttributeValue("Name")!;
            }
        }
    }
}
