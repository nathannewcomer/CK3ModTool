using CK3ModTool.Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CK3ModTool.Parser
{
    public class Tokenizer
    {
        public Tokens Token { get; private set; }
        public string Identifier { get; private set; }
        public int Number { get; private set; }
        public double Double { get; private set; }

        public int Line { get; private set; }
        public int Column { get; private set; }

        private StreamReader file;

        private const string REGEX = "[a-zA-Z0-9]|=|{|}|@|_|:";

        public Tokenizer(StreamReader streamReader)
        {
            file = streamReader;
            NextToken();
        }

        public void NextToken()
        {
            char c = ReadChar();

            // end of file
            if (c == char.MinValue)
            {
                Token = Tokens.EOF;
                return;
            }

            // ignore comments and whitespace
            while (!file.EndOfStream && c == '#' || char.IsWhiteSpace(c))
            {
                // comments - ignore whole line
                if (c == '#')
                {
                    while (!file.EndOfStream && c != '\n')
                    {
                        c = ReadChar();
                    }

                    c = ReadChar();    // \n
                }

                // whitespace
                if (char.IsWhiteSpace(c))
                {
                    while (!file.EndOfStream && char.IsWhiteSpace(c))
                    {
                        c = ReadChar();
                    }
                }
            }

            // end of file
            if (c == char.MinValue)
            {
                Token = Tokens.EOF;
                return;
            }

            // make sure char is a valid symbol
            Match match = Regex.Match(c.ToString(), REGEX);
            if (!match.Success)
            {
                Debug.WriteLine($"ERROR: char {c} is not a valid character.");
            }

            // single character symbols
            switch (c)
            {
                case '{':
                    Token = Tokens.LBRACKET;
                    return;
                case '}':
                    Token = Tokens.RBRACKET;
                    return;
                case '=':
                    Token = Tokens.EQUALS;
                    return;
            }

            // build word
            string word = string.Empty;
            while (PeekChar() != char.MinValue && PeekChar() != '\n' && char.IsLetterOrDigit(PeekChar()) || PeekChar() == '@' || PeekChar() == '_' || PeekChar() == '.')
            {
                word += c;
                c = ReadChar();
            }

            // see if this is a number
            int number;
            if (int.TryParse(word, out number))
            {
                Number = number;
                Token = Tokens.NUMBER;
                return;
            }

            // see if this is a double
            double num;
            if (double.TryParse(word, out num))
            {
                Double = num;
                Token = Tokens.DOUBLE;
                return;
            }

            Identifier = word;
            Token = Tokens.IDENTIFIER;

        }

        /// <summary>
        /// Helper method to retreive the next character. Ignores newlines and updates line and column numbers.
        /// </summary>
        /// <returns>The next character in the file</returns>
        private char ReadChar()
        {
            int n = file.Read();

            // end of file
            if (n == -1)
            {
                return char.MinValue;
            }

            char c = (char)n;

            // newline
            if (c == '\r')
            {
                c = (char)file.Read();  // \n
                Line++;
                Column = 0;

                return c;
            }
            else
            {
                Column++;
                return c;
            }
            
        }

        private char PeekChar()
        {
            return (char)file.Peek();
        }

    }
}
