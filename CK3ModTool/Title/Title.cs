using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK3ModTool.Title
{
    public class Title
    {
        public string Name { get; set; }
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Dictionary<string, string> KeyValues { get; set; }
        public List<Title> SubDomains { get; set; }
        // TODO: logic

        public Title()
        {
            KeyValues = new Dictionary<string, string>();
            SubDomains = new List<Title>();
        }
    }
}
