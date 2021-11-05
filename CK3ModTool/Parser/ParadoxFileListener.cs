using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK3ModTool.Parser
{
    public class ParadoxFileListener : ParadoxBaseListener
    {

        public override void EnterFile([NotNull] ParadoxParser.FileContext context) {
            Debug.WriteLine(context.GetText());
        }


    }
}
