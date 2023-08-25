    #nullable enable

    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.IO;
    using System.Collections.Generic;


    namespace BG3LootTableGenerator.DataStructures
    {
        public class Localization
        {
            private readonly Dictionary<string, string> _entries = new();
            // Expose the _entries dictionary

            public IReadOnlyDictionary<string, string> Entries => _entries;


            // Constructor
            public Localization(string path)
            {
                LoadFrom(path);
            }

        private string? FindEnglishXmlFile(string rootDirectory)
        {
            var files = Directory.GetFiles(rootDirectory, "english.xml", SearchOption.AllDirectories);
            return files.FirstOrDefault();
        }

        // LoadFrom method to populate the _entries dictionary from an XML file
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


        // TryGetValue method to retrieve a value from the _entries dictionary
        public bool TryGetValue(string key, out string value)
            {
                return _entries.TryGetValue(key, out value);
            }

            // Add method to add a key-value pair to the _entries dictionary
            public void Add(string key, string value)
            {
                _entries[key] = value;
            }
        }
    }
