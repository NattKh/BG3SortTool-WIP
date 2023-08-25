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

            // LoadFrom method to populate the _entries dictionary from an XML file
            private void LoadFrom(string path)
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"The specified XML file was not found: {path}");
                }

                XDocument doc = XDocument.Load(path);
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
