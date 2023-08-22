using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG3LootTableGenerator.DataStructures;  // Remember to import your data structures.
// ... (other using directives)

public class LootTableGenerator
{
    private Dictionary<string, ItemEntry> _entries = new();
    private Dictionary<string, string> _localization = new();

    // Here, instead of CmdlineOptions, I'm suggesting passing source and destination directories directly.
    public void Generate(string sourceDir, string destDir)
    {
        // ... (rest of your logic)
        // Essentially, the entire content of the Run method.
    }

    private IEnumerable<string> GetAllRootTemplates(string dir)
    {
        return Directory
            .EnumerateFiles(Path.Combine(dir), "*.lsx", SearchOption.AllDirectories)
            .Where(x => Path.GetDirectoryName(x)!.EndsWith("RootTemplates"))
            .Select(x => x.Replace('\\', '/'));
    }
}

