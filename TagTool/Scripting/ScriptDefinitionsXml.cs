using System;
using System.Collections.Generic;
using System.Xml;

namespace TagTool.Scripting
{
    public class ScriptDefinitionsXml : IScriptDefinitions
    {
        private readonly string _filePath;
        private readonly Dictionary<int, string> _types = [];
        private readonly Dictionary<int, string> _globals = [];
        private readonly Dictionary<int, ScriptInfo> _functions = [];

        public ScriptDefinitionsXml(string filePath)
        {
            _filePath = filePath;
            Load();
        }

        IReadOnlyDictionary<int, string> IScriptDefinitions.ValueTypes => _types;
        IReadOnlyDictionary<int, string> IScriptDefinitions.Globals => _globals;
        IReadOnlyDictionary<int, ScriptInfo> IScriptDefinitions.Scripts => _functions;

        private void Load()
        {
            using XmlReader reader = XmlReader.Create(_filePath);
            Load(reader);
        }

        private void Load(XmlReader reader)
        {
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "types":
                        ReadTypes(reader, _types);
                        break;
                    case "globals":
                        ReadGlobals(reader, _globals);
                        break;
                    case "functions":
                        ReadFunctions(reader, _functions);
                        break;
                }
            }
        }

        private static void ReadFunctions(XmlReader reader, Dictionary<int, ScriptInfo> functions)
        {
            while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name != "function")
                        throw new FormatException("Expected function element");

                    int opCode = Convert.ToInt32(reader.GetAttribute("opcode"), 16);

                    var function = new ScriptInfo()
                    {
                        Name = reader.GetAttribute("name"),
                        Type = HsTypeFromString(reader.GetAttribute("type")),
                        Parameters = []
                    };

                    if (!reader.IsEmptyElement)
                        ReadArgs(reader, function.Parameters);

                    functions.Add(opCode, function);
                }
            }
        }

        private static void ReadArgs(XmlReader reader, List<ScriptInfo.ParameterInfo> args)
        {
            while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name != "arg")
                        throw new FormatException("Expected arg element");

                    string type = reader.GetAttribute("type");
                    args.Add(new ScriptInfo.ParameterInfo(HsTypeFromString(type)));
                }
            }
        }

        private static void ReadGlobals(XmlReader reader, Dictionary<int, string> globals)
        {
            while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name != "global")
                        throw new FormatException("Expected global element");

                    int opcode = Convert.ToInt32(reader.GetAttribute("opcode"), 16);
                    string name = reader.GetAttribute("name");
                    globals.Add(opcode, name);

                }
            }
        }

        private static void ReadTypes(XmlReader reader, Dictionary<int, string> types)
        {
            while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name != "type")
                        throw new FormatException("Expected type element");

                    int opcode = Convert.ToInt32(reader.GetAttribute("opcode"), 16);
                    string name = reader.GetAttribute("name");
                    types.Add(opcode, name);
                }
            }
        }

        private static HsType HsTypeFromString(string type)
        {
            return Enum.Parse<HsType>(type.ToPascalCase());
        }
    }
}
