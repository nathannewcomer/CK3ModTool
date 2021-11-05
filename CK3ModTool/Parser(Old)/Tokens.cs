using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK3ModTool.Parser
{
    public enum Tokens
    {
        IDENTIFIER,
        NUMBER,
        DOUBLE,

        EQUALS,
        LBRACKET,
        RBRACKET,
        EOF
    }
}
