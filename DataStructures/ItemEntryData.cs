using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG3LootTableGenerator.DataStructures
{
    public record ItemEntryData(string? ParentTemplateId, string? VisualTemplateId, string? Stats, string? Icon);
}



