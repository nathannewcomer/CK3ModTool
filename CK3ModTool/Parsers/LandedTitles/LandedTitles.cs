using System.Collections.Generic;
using System.IO;

namespace CK3ModTool.Parsers.LandedTitles
{
    class LandedTitles
    {
        /// <summary>
        /// Holds variables (declared with @) and their values.
        /// </summary>
        public Dictionary<string, int> Variables { get; set; }
        public List<Title> Titles { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public LandedTitles()
        {
            Variables = new Dictionary<string, int>();
        }

        public void ParseTitles(string filePath)
        {
            List<TitleToken> tokens = new List<TitleToken>();
            StreamReader file = File.OpenText(filePath);
            string token;
            char c;


            while ((c = (char)file.Read()) >= 0)
            {

                switch (c)
                {
                    case '{':
                        tokens.Add(TitleToken.LPAREN);
                        break;
                    case '}':
                        tokens.Add(TitleToken.RPAREN);
                        break;
                    case '=':
                        tokens.Add(TitleToken.EQUALS);
                        break;
                }

            }

        }
    }

    internal enum TitleToken
    {
        VARIABLE,
        NUM,
        TITLE,
        
        EQUALS,
        LPAREN,
        RPAREN,

        KEY,
        VALUE
    }
}
