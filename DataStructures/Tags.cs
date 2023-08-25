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
                LoadFrom(filePath);
            }
        }

        public void LoadFrom(string rootDirectory)
        {
            string? xmlFilePath = FindEnglishXmlFile(rootDirectory);
            if (xmlFilePath == null)
            {
                throw new FileNotFoundException($"Could not find the XML file in the specified directory or its subdirectories: {rootDirectory}");
            }

            XDocument doc = XDocument.Load(xmlFilePath);
            foreach (XElement elem in doc.XPathSelectElements("contentList/content"))
            {
                string key = elem.Attribute("contentuid")?.Value ?? string.Empty;
                string value = elem.Value;
                _entries[key] = value;
            }
        }

        private string? FindEnglishXmlFile(string rootDirectory)
        {
            var files = Directory.GetFiles(rootDirectory, "english.xml", SearchOption.AllDirectories);
            return files.FirstOrDefault();
        }
    }
}
