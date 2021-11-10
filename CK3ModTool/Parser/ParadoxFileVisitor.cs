using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParadoxParser;

namespace CK3ModTool.Parser
{
    public class ParadoxFileVisitor : ParadoxBaseVisitor<object>
    {
        public override List<Pair> VisitFile([NotNull] ParadoxParser.FileContext context)
        {
            List<Pair> pairs = context.pair().Select(p => VisitPair(p)).ToList();
            return pairs;
        }

        public override Pair VisitPair([NotNull] ParadoxParser.PairContext context)
        {
            Pair pair = new Pair();
            pair.Identifier = context.IDENTIFIER().GetText();
            pair.Val = VisitValue(context.value());
            return pair;
        }

        public override Value VisitValue([NotNull] ValueContext context)
        {
            Value value = new Value();
            if (context.IDENTIFIER() is not null)
            {
                value.Identifier = context.IDENTIFIER().GetText();
            }
            else if (context.NUMBER() is not null)
            {
                value.Identifier = context.NUMBER().GetText();
            }
            else
            {
                value.Object = VisitObject(context.@object());
            }
            return value;
        }

        public override PObject VisitObject([NotNull] ObjectContext context)
        {
            PObject pObject = new PObject();
            if (context.IDENTIFIER() is not null)
            {
                pObject.Prefix = context.IDENTIFIER().GetText();
            }
            pObject.InnerContents = VisitContents(context.contents());
            return pObject;
        }

        public override Contents VisitContents([NotNull] ContentsContext context)
        {
            Contents contents = new Contents();
            if (context.pair() is not null)
            {
                contents.Pairs = context.pair().Select(p => VisitPair(p)).ToList();
            }
            else
            {
                contents.List = VisitList(context.list());
            }
            return contents;
        }

        public override List<string> VisitList([NotNull] ListContext context)
        {
            List<string> list;
            if (context.IDENTIFIER() is not null)
            {
                list = context.IDENTIFIER().Select(l => l.GetText()).ToList();
            }
            else
            {
                list = context.NUMBER().Select(l => l.GetText()).ToList();
            }

            return list;
        }
    }
}
