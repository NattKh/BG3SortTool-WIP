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

        public IEnumerable<string> GetAllTagNames()
        {
            return _entries.Values;
        }

        public Tags(string sourceDir)
        {
            foreach (string filePath in Util.GetAllTemplates(Path.Combine(sourceDir, "Tags")).Progress("Loading tags"))
            {
                ProcessLsxFile(filePath);
            }
        }

        public void ProcessLsxFile(string path)
        {
            XDocument doc = XDocument.Load(path);
            foreach (XElement elem in doc.XPathSelectElements("region[@id = 'Tags']/node[@id = 'Tags']"))
            {
                string key = elem.Attribute("contentuid")?.Value ?? string.Empty;
                string value = elem.Value;
                _entries[key] = value;
            }
        }
    }
}