using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK3ModTool.Parser
{
    public class Pair
    {
        public string Identifier { get; set; }
        public Value Val { get; set; }
    }

    public class Value
    {
        public string Identifier { get; set; }
        public PObject Object { get; set; }
    }

    public class PObject
    {
        public string Prefix { get; set; }
        public Contents InnerContents { get; set; }
    }

    public class Contents
    {
        public List<string> List { get; set; }
        public List<Pair> Pairs { get; set; }
    }
}
