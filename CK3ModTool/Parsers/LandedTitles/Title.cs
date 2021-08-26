using System.Collections.Generic;
using System.Drawing;

namespace CK3ModTool.Parsers.LandedTitles
{
    class Title
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Color Color2 { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}
