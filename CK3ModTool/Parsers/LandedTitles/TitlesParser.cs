using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CK3ModTool.Parsers.LandedTitles
{
    class TitlesParser
    {
        public TitleToken Token { get; private set; }
        public string Identifier { get; private set; }
        public string Variable { get; private set; }
        public int Number { get; private set; }

        public int Line { get; private set; }
        public int Column { get; private set; }

        private StreamReader file;

        private const string GRAMMAR = "\\w|\\d|=|{|}";

        public TitlesParser(StreamReader streamReader)
        {
            file = streamReader;
        }

        public void NextToken()
        {
            char c = (char)file.Read();

            // remove whitespace
            while (!file.EndOfStream && char.IsWhiteSpace(c))
            {
                c = (char)file.Read();
            }

            // ignore comments
            if (c == '#')
            {
                while (!file.EndOfStream && c != '\n')
                {
                    c = (char)file.Read();
                }

                c = (char)file.Read();
            }

            // end of file
            if (c == -1)
            {
                Token = TitleToken.EOF;
                return;
            }

            // make sure char is a valid symbol
            Match match = Regex.Match(c.ToString(), GRAMMAR);
            if (!match.Success)
            {
                Debug.WriteLine($"ERROR: char {c} is not a valid character.");
            }

            // single character symbols
            switch (c)
            {
                case '{':
                    Token = TitleToken.LPAREN;
                    return;
                case '}':
                    Token = TitleToken.RPAREN;
                    return;
                case '=':
                    Token = TitleToken.EQUALS;
                    return;
            }

            // build word
            string word = string.Empty;
            while (!file.EndOfStream && Regex.Match(c.ToString(), GRAMMAR).Success)
            {
                word += c;
                c = (char)file.Read();
            }

            // see if this is a number
            int number;
            if (int.TryParse(word, out number))
            {
                Number = number;
                return;
            }

            // 

        }

    }

    internal enum TitleToken
    {
        IDENTIFIER,
        NUMBER,

        EQUALS,
        LPAREN,
        RPAREN,
        EOF
    }
}
