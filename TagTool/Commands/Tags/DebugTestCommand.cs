using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TagTool.BlamFile;
using TagTool.BlamFile.MCC;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.JSON.Handlers;
using TagTool.JSON.Objects;
using TagTool.Scripting;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, CommandContextStack contextStack) : base
        (
            false,
            "DebugTest",
            "Self Explanatory",

            "DebugTest",
            "Self Explanatory"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            var XMLData = File.ReadAllText(args[0]);

            var functions = ParseFunctions(XMLData);

            GenerateFunctions(functions);

            return true;
        }

        public static void GenerateFunctions(ScriptInfoData scriptInfo)
        {
            using (var writer = new StreamWriter($"{ParseVersion(scriptInfo.Version)}.xml"))
            {
                var indent = "  ";

                writer.WriteLine($"<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine($"<hs>");
                writer.WriteLine($"{indent}<types>");

                foreach (var type in scriptInfo.ValueTypes)
                {
                    var indexString = $"{type.Opcode:X}".Replace("0x", "");

                    writer.WriteLine($"{indent}{indent}<type opcode=\"0x{indexString}\" name=\"{(type.Name != "" ? type.Name : $"unknown{type.Opcode}")}\" />");
                }

                writer.WriteLine($"{indent}</types>");
                writer.WriteLine($"{indent}<globals>");

                foreach (var global in scriptInfo.Globals)
                {
                    var indexString = $"{global.Opcode:X}".Replace("0x", "");

                    writer.WriteLine($"{indent}{indent}<global opcode=\"0x{indexString}\" name=\"{(global.Name != "" && global.Name != null ? global.Name : $"unknown{indexString}")}\" type=\"{global.Type}\" />");
                }

                writer.WriteLine($"{indent}</globals>");
                writer.WriteLine($"{indent}<functions>");

                foreach (var scripts in scriptInfo.Scripts)
                {
                    var indexString = $"{scripts.Opcode:X}".Replace("0x", "");

                    if (scripts.ArgCount > 0)
                    {
                        writer.WriteLine($"{indent}{indent}<function opcode=\"0x{indexString}\" name=\"{scripts.Name}\" type=\"{scripts.ReturnType}\">");

                        foreach (var parameter in scripts.Arguments)
                        {
                            writer.WriteLine($"{indent}{indent}{indent}<arg type=\"{parameter.Type}\" />");
                        }

                        writer.WriteLine($"{indent}{indent}</function>");
                    }
                    else
                    {
                        writer.WriteLine($"{indent}{indent}<function opcode=\"0x{indexString}\" name=\"{scripts.Name}\" type=\"{scripts.ReturnType}\" />");
                    }
                }

                writer.WriteLine($"{indent}</functions>");
                writer.WriteLine($"</hs>");
            }
        }

        public static ScriptInfoData ParseFunctions(string xmlContent)
        {
            XDocument xmlDoc = XDocument.Parse(xmlContent);

            var scriptInfoData = new ScriptInfoData
            {
                ValueTypes = new List<ScriptInfoData.ValueTypeData>(),
                Globals = new List<ScriptInfoData.GlobalData>(),
                Scripts = new List<ScriptInfoData.FunctionData>(),
            };

            foreach (XElement element in xmlDoc.Descendants("BlamScript"))
            {
                scriptInfoData.Version = element.Attribute("game")?.Value;
            }

            foreach (XElement valueTypes in xmlDoc.Descendants("valueTypes"))
            {
                foreach (XElement valueTypeElement in valueTypes.Descendants("type"))
                {
                    ScriptInfoData.ValueTypeData valueType = new ScriptInfoData.ValueTypeData
                    {
                        Opcode = valueTypeElement.Attribute("opcode")?.Value,
                        Name = valueTypeElement.Attribute("name")?.Value,
                        Size = int.TryParse(valueTypeElement.Attribute("size")?.Value, out int size) ? size : 0,
                        Tag = valueTypeElement.Attribute("tag")?.Value,
                        Quoted = bool.TryParse(valueTypeElement.Attribute("quoted")?.Value, out bool quoted) ? quoted : false,
                    };

                    scriptInfoData.ValueTypes.Add(valueType);
                }
            }

            foreach (XElement globals in xmlDoc.Descendants("globals"))
            {
                foreach (XElement globalElement in globals.Descendants("global"))
                {
                    ScriptInfoData.GlobalData global = new ScriptInfoData.GlobalData
                    {
                        Opcode = globalElement.Attribute("opcode")?.Value,
                        Name = globalElement.Attribute("name")?.Value,
                        Null = bool.TryParse(globalElement.Attribute("null")?.Value, out bool isNull) ? isNull : false,
                        Type = globalElement.Attribute("type")?.Value,
                    };

                    scriptInfoData.Globals.Add(global);
                }
            }

            foreach (XElement functions in xmlDoc.Descendants("functions"))
            {
                foreach (XElement functionElement in functions.Descendants("function"))
                {
                    ScriptInfoData.FunctionData function = new ScriptInfoData.FunctionData
                    {
                        Opcode = functionElement.Attribute("opcode")?.Value,
                        Name = functionElement.Attribute("name")?.Value,
                        ReturnType = functionElement.Attribute("returnType")?.Value,
                        Flags = int.TryParse(functionElement.Attribute("flags")?.Value, out int flags) ? flags : 0,
                        Group = functionElement.Attribute("group")?.Value,
                        ArgCount = int.TryParse(functionElement.Attribute("argc")?.Value, out int argCount) ? argCount : 0,
                    };

                    if (function.ArgCount > 0)
                    {
                        function.Arguments = new List<ScriptInfoData.FunctionData.FunctionArgument>();

                        foreach (XElement argumentElement in functionElement.Descendants("arg"))
                        {
                            ScriptInfoData.FunctionData.FunctionArgument argument = new ScriptInfoData.FunctionData.FunctionArgument
                            {
                                Type = argumentElement.Attribute("type")?.Value,
                            };

                            function.Arguments.Add(argument);
                        }
                    }

                    scriptInfoData.Scripts.Add(function);
                }
            }

            return scriptInfoData;
        }

        public static string ParseVersion(string version)
        {
            switch (version)
            {
                case "Halo3_Xbox":
                    return "halo3";
                case "Halo3_MCC":
                    return "halo3_mcc";
                case "Halo3Odst_Xbox":
                    return "halo3_odst";
                case "Halo3Odst_MCC":
                    return "halo3_odst_mcc";
                case "eldorado":
                    return "halo_online_106708"; // Don't really know how to check for 0.7 :/
                case "HaloReach_Xbox":
                    return "halo_reach";
                case "HaloReach_MCC":
                    return "halo_reach_mcc";
                default:
                    return version;
            }
        }

        public class ScriptInfoData
        {
            public string Version;
            public List<ValueTypeData> ValueTypes;
            public List<GlobalData> Globals;
            public List<FunctionData> Scripts;

            public class ValueTypeData
            {
                public string Opcode { get; set; }
                public string Name { get; set; }
                public int Size { get; set; }
                public string Tag { get; set; }
                public bool Quoted { get; set; }
            }

            public class GlobalData
            {
                public string Opcode { get; set; }
                public string Name { get; set; }
                public bool Null { get; set; }
                public string Type { get; set; }
            }

            public class FunctionData
            {
                public string Opcode { get; set; }
                public string Name { get; set; }
                public string ReturnType { get; set; }
                public int Flags { get; set; }
                public string Group { get; set; }
                public int ArgCount { get; set; }
                public List<FunctionArgument> Arguments { get; set; }

                public class FunctionArgument
                {
                    public string Type { get; set; }
                }
            }
        }
    }
}
