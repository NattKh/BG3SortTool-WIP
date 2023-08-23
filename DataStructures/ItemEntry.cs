namespace BG3LootTableGenerator.DataStructures
{
    public record ItemEntry(string Name, string? Inheritance, string MapKey, string Path, ItemEntryData Data, ItemEntryLocalization Localization)
    {
        public bool InheritsFrom(string name) => Inheritance?.Split(':').Any(x => x == name) ?? false;

        public string? GetStats(IEnumerable<ItemEntry> entries)
        {
            if (!string.IsNullOrWhiteSpace(Data.Stats))
            {
                return Data.Stats;
            }

            foreach (string candidate in Inheritance?.Split(':').Reverse().Skip(1) ?? Enumerable.Empty<string>())
            {
                ItemEntry? parent = entries.First(x => candidate == x.Name); // TODO: Should be MapKey to be safe?
                if (!string.IsNullOrWhiteSpace(parent.Data.Stats)) return parent.Data.Stats;
            }

            Console.WriteLine($"Warning: Couldn't find stats for {Name} / {MapKey}");
            return null;
        }
    }
}
