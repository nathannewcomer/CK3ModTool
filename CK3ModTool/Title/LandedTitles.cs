using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK3ModTool.Title
{
    public class LandedTitles
    {
        public Dictionary<string, int> Variables { get; internal set; }
        public List<Title> Titles { get; internal set; }

        public LandedTitles()
        {
            Variables = new Dictionary<string, int>();
            Titles = new List<Title>();
        }
    }
}
