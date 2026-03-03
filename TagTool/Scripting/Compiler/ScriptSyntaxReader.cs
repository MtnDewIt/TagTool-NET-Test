using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagTool.Scripting.Compiler
{
    public class ScriptSyntaxReader
    {
        public BinaryReader Reader { get; }

        public int Line = 1;
        public int ParenDepth = 0;

        // Stack of line numbers where '(' was opened, so we can report the
        // outermost unclosed one rather than the deepest recursive call site.
        private readonly Stack<int> _openLines = new Stack<int>();

        public ScriptSyntaxReader(Stream stream)
        {
            Reader = new BinaryReader(stream);
        }

        public const string Delimiters = "()\"'`,;";

        public bool LastTokenValid = false;
        public string LastToken = "";

        public void SetLastToken(string token)
        {
            LastToken = token;
            LastTokenValid = true;
        }

        public string ReadToken()
        {
            var result = "";

            if (LastTokenValid)
            {
                result = LastToken;
                LastToken = "";
                LastTokenValid = false;
                return result;
            }

            if (Reader.BaseStream.Position >= Reader.BaseStream.Length)
                return "eof";

            var c = '\0';
            while ((Reader.BaseStream.Position < Reader.BaseStream.Length) && char.IsWhiteSpace(c = Reader.ReadChar()))
            {
                if (c == '\n')
                    Line++;
            }

            if (Reader.BaseStream.Position >= Reader.BaseStream.Length)
                return "eof";

            if (Delimiters.Contains(c))
                return c.ToString();

            result += c;

            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
            {
                c = Reader.ReadChar();

                if (c == '\n')
                    Line++;

                if (Delimiters.Contains(c) || char.IsWhiteSpace(c))
                {
                    Reader.BaseStream.Position--;
                    break;
                }

                result += c;
            }

            return result;
        }

        public IScriptSyntax ReadGroup()
        {
            int openLine = Line;
            var token = ReadToken();

            switch (token)
            {
                case ")":
                    ParenDepth--;
                    if (_openLines.Count > 0) _openLines.Pop();
                    return new ScriptInvalid { Line = Line };

                case "eof":
                    if (ParenDepth > 0)
                    {
                        int errorLine = _openLines.Count > 0 ? _openLines.Peek() : openLine;
                        throw new ScriptCompilerException(errorLine,
                            "Unclosed '(' - this expression was never closed.");
                    }
                    return new ScriptInvalid { Line = openLine };

                case ".":
                    {
                        var node = Read();
                        token = ReadToken();

                        if (token == "eof")
                            throw new ScriptCompilerException(Line,
                                "Unexpected end of file after '.' - expected a closing ')'.");

                        if (token != ")")
                            throw new ScriptCompilerException(Line,
                                $"Expected ')' after dotted expression but found '{token}'.");

                        return node;
                    }

                default:
                    break;
            }

            SetLastToken(token);

            return new ScriptGroup
            {
                Head = Read(),
                Tail = ReadGroup(),
                Line = Line
            };
        }

        public ScriptString ReadString()
        {
            var result = "";
            int stringStartLine = Line;

            while (true)
            {
                if (Reader.BaseStream.Position >= Reader.BaseStream.Length)
                    throw new ScriptCompilerException(stringStartLine,
                        "Unterminated string - the '\"' opened here was never closed.");

                char c = Reader.ReadChar();

                if (c == '"')
                    break;

                if (c == '\n')
                    Line++;

                result += c;
            }

            return new ScriptString
            {
                Value = result,
                Line = Line
            };
        }

        public IScriptSyntax ReadQuote()
        {
            return new ScriptGroup
            {
                Head = new ScriptSymbol { Value = "quote", Line = Line },
                Tail = new ScriptGroup
                {
                    Head = Read(),
                    Tail = new ScriptInvalid(),
                    Line = Line
                }
            };
        }

        public IScriptSyntax ReadQuasiQuote()
        {
            return new ScriptGroup
            {
                Head = new ScriptSymbol { Value = "quasiquote", Line = Line },
                Tail = new ScriptGroup
                {
                    Head = Read(),
                    Tail = new ScriptInvalid(),
                    Line = Line
                }
            };
        }

        public IScriptSyntax ReadUnquote()
        {
            return new ScriptGroup
            {
                Head = new ScriptSymbol { Value = "unquote", Line = Line },
                Tail = new ScriptGroup
                {
                    Head = Read(),
                    Tail = new ScriptInvalid(),
                    Line = Line
                }
            };
        }

        public IScriptSyntax Read()
        {
        begin:
            if (Reader.BaseStream.Position >= Reader.BaseStream.Length)
                return new EndOfFile { Line = Line };

            var token = ReadToken();

            switch (token)
            {
                case "eof":
                    return new EndOfFile { Line = Line };

                case "(":
                    ParenDepth++;
                    _openLines.Push(Line);
                    return ReadGroup();

                case "\"":
                    return ReadString();

                case "'":
                    return ReadQuote();

                case "`":
                    return ReadQuasiQuote();

                case ",":
                    return ReadUnquote();

                case ";":
                    for (char c; (Reader.BaseStream.Position < Reader.BaseStream.Length) && ((c = Reader.ReadChar()) != '\r' && c != '\n');)
                    {
                        // consume until end of line
                    }
                    goto begin;

                default:
                    if (bool.TryParse(token, out var boolean))
                        return new ScriptBoolean { Value = boolean, Line = Line };
                    else if (long.TryParse(token, out var integer))
                        return new ScriptInteger { Value = integer, Line = Line };
                    else if (double.TryParse(token, out var real))
                        return new ScriptReal { Value = real, Line = Line };
                    else
                        return new ScriptSymbol { Value = token, Line = Line };
            }
        }

        public List<IScriptSyntax> ReadToEnd()
        {
            var nodes = new List<IScriptSyntax>();

            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
            {
                var node = Read();

                if (node is EndOfFile)
                    break;

                nodes.Add(node);
            }

            return nodes;
        }
    }
}
