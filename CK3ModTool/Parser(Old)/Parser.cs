using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK3ModTool.Parser
{
    
    public class PFile
    {
        public Dictionary<string, string> KeyValues { get; private set; }
        public List<PObject> Objects { get; private set; }

        public PFile()
        {
            KeyValues = new Dictionary<string, string>();
            Objects = new List<PObject>();
        }

        public void Parse(Tokenizer tokenizer)
        {
            while (tokenizer.Token != Tokens.EOF)
            {
                if (tokenizer.Token != Tokens.IDENTIFIER)
                {
                    throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "IDENTIFIER", tokenizer.Token));
                }

                string name = tokenizer.Identifier;

                tokenizer.NextToken();
                if (tokenizer.Token != Tokens.EQUALS)
                {
                    throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "EQUALS", tokenizer.Token));
                }

                tokenizer.NextToken();

                string value = null;
                switch (tokenizer.Token)
                {
                    case Tokens.IDENTIFIER:
                        value = tokenizer.Identifier;
                        break;
                    case Tokens.NUMBER:
                        value = tokenizer.Number.ToString();
                        break;
                    case Tokens.DOUBLE:
                        value = tokenizer.Double.ToString();
                        break;
                }

                // KEYVALUE
                if (value is not null)
                {
                    KeyValues.Add(name, value);
                    tokenizer.NextToken();
                    continue;
                }

                // OBJECT
                if (tokenizer.Token != Tokens.LBRACKET)
                {
                    throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "LBRACKET", tokenizer.Token));
                }

                tokenizer.NextToken();
                PObject obj = new PObject(name);
                obj.Parse(tokenizer);
                Objects.Add(obj);

                if (tokenizer.Token != Tokens.RBRACKET)
                {
                    throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "RBRACKET", tokenizer.Token));
                }
                tokenizer.NextToken();
            }
        }

        public string Print()
        {
            string output = string.Join("\n", KeyValues.Select(x => string.Format("{0} = {1}", x.Key, x.Value)));
            
            foreach (PObject o in Objects) {
                output += o.Print("");
            }

            return output.ToString();
        }
    }

    public class PObject
    {
        public string Name { get; private set; }
        public PContents Contents { get; internal set; }

        public PObject(string name)
        {
            Name = name;
        }

        public void Parse(Tokenizer tokenizer)
        {
            Contents = new PContents();
            Contents.Parse(tokenizer);
        }

        public string Print(string pad)
        {
            string output = string.Format("{0}{1} = {{\n", pad, Name);
            output += Contents.Print(pad + "\t");
            output += "\n" + pad + "}";

            return output;
        }
    }

    public class PContents
    {
        public List<string> List { get; private set; }
        public List<PObject> Objects { get; private set; }
        public Dictionary<string, string> KeyValues { get; private set; }

        public PContents()
        {
            List = new List<string>();
            Objects = new List<PObject>();
            KeyValues = new Dictionary<string, string>();
        }

        public void Parse(Tokenizer tokenizer)
        {
            while (tokenizer.Token != Tokens.RBRACKET) {

                string name;
                if (tokenizer.Token == Tokens.IDENTIFIER)
                {
                    name = tokenizer.Identifier;
                }
                // number list
                else if (tokenizer.Token == Tokens.NUMBER || tokenizer.Token == Tokens.DOUBLE)
                {
                    while (tokenizer.Token != Tokens.RBRACKET)
                    {
                        if (tokenizer.Token != Tokens.NUMBER && tokenizer.Token != Tokens.DOUBLE)
                        {
                            throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "NUMBER or DOUBLE", tokenizer.Token));
                        }

                        string num = tokenizer.Token == Tokens.NUMBER ? tokenizer.Number.ToString() : tokenizer.Double.ToString();
                        List.Add(num);
                        tokenizer.NextToken();
                    }

                    return;
                }
                else
                {
                    throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "IDENTIFIER or NUMBER or DOUBLE", tokenizer.Token));
                }

                tokenizer.NextToken();
                if (tokenizer.Token == Tokens.EQUALS)
                {
                    tokenizer.NextToken();

                    // object
                    if (tokenizer.Token == Tokens.LBRACKET)
                    {
                        tokenizer.NextToken();

                        PObject obj = new PObject(name);
                        obj.Parse(tokenizer);
                        Objects.Add(obj);

                        if (tokenizer.Token != Tokens.RBRACKET)
                        {
                            throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "RBRACKET", tokenizer.Token));
                        }
                        tokenizer.NextToken();

                        continue;
                    }
                    // KeyValue
                    else if (tokenizer.Token == Tokens.IDENTIFIER || tokenizer.Token == Tokens.NUMBER)
                    {
                        string value = tokenizer.Token == Tokens.IDENTIFIER ? tokenizer.Identifier : tokenizer.Number.ToString();
                        if (KeyValues.ContainsKey(name))
                        {
                            name = "#" + name;
                        }
                        KeyValues.Add(name, value);

                        tokenizer.NextToken();
                    }
                    else
                    {
                        throw new FormatException(string.Format("line {0} column {1} - expected token {2} but got {3}", tokenizer.Line, tokenizer.Column, "LBRACKET or IDENTIFIER or NUMBER", tokenizer.Token));
                    }
                }
                else if (tokenizer.Token == Tokens.IDENTIFIER)
                {
                    // list
                    while (tokenizer.Token != Tokens.RBRACKET)
                    {
                        List.Add(tokenizer.Identifier);
                        tokenizer.NextToken();
                    }
                }
            }
        }

        public string Print(string pad)
        {
            string output = "";

            if (List.Count > 0)
            {
                output += pad + string.Join(" ", List);
            }
            else
            {
                output += string.Join("\n", KeyValues.Select(x => string.Format("{0}{1} = {2}", pad, x.Key.Replace("#", ""), x.Value)));
                if (KeyValues.Count > 0 && Objects.Count > 0)
                {
                    output += "\n";
                }
                output += string.Join("\n", Objects.Select(o => o.Print(pad)));
            }

            return output;
        }
    }
}
