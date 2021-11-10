using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK3ModTool.Title
{
    public class ParadoxTitlesVisitor : ParadoxBaseVisitor<object>
    {
        public override LandedTitles VisitFile([NotNull] ParadoxParser.FileContext context)
        {
            LandedTitles landedTitles = new LandedTitles();

            

            return landedTitles;
        }

        public override List<string> VisitList([NotNull] ParadoxParser.ListContext context)
        {
            List<string> list = new List<string>();
            ITerminalNode[] ids = context.IDENTIFIER().Length > 0 ? context.IDENTIFIER() : context.NUMBER();

            return ids.Select(i => i.GetText()).ToList();
        }
    }
}
