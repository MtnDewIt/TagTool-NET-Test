using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using TagTool.Cache;
using TagTool.Commands.Common;

namespace TagTool.Commands.Strings
{
    public class DumpStringIdNamespacesCommand : Command
    {
        private readonly GameCache Cache;

        public DumpStringIdNamespacesCommand(GameCache cache) :
            base(true,

                "DumpStringIdNamespaces",
                "Dumps the string id namespaces to an xml file",

                "DumpStringIdNamespaces <path>",

                "")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1)
                return new TagToolError(CommandError.ArgCount);

            if (Cache.StringTable.Resolver.SetBits == 0)
                return new TagToolError(CommandError.OperationFailed, "Cache does not use namespaced string ids");

            DumpNamespacesXml(Cache.StringTable, args[0]);
            return true;
        }

        public static void DumpNamespacesXml(StringTable stringTable, string savePath)
        {
            var namespaces = DumpNamespaces(stringTable);

            using var writer = XmlWriter.Create(savePath, new XmlWriterSettings() { Indent = true });
            writer.WriteStartDocument();
            writer.WriteStartElement("namespaces");
            foreach (var (id, members) in namespaces)
            {
                writer.WriteStartElement("namespace");
                writer.WriteAttributeString("id", $"{id}");

                int firstMember = id == 0 ? 1 : 0; // exclude empty
                for (int i = firstMember; i < members.Count; i++)
                {
                    writer.WriteStartElement("member");
                    writer.WriteAttributeString("global_index", $"0x{members[i].index:X}");
                    writer.WriteAttributeString("index", $"0x{i:X}");
                    writer.WriteAttributeString("string", $"{members[i].str}");
                    writer.WriteEndElement(); // member
                }
                writer.WriteEndElement(); // namespace
            }
            writer.WriteEndElement(); // namespaces
            writer.WriteEndDocument();
        }

        public static Dictionary<int, List<(int index, string str)>> DumpNamespaces(StringTable stringTable)
        {
            int[] setOffsets = stringTable.Resolver.GetSetOffsets();
            int setMin = stringTable.Resolver.GetMinSetStringIndex();
            int setMax = stringTable.Resolver.GetMaxSetStringIndex();

            var sortedSets = setOffsets.Select((offset, id) => (offset, id)).ToArray();
            Array.Sort(sortedSets, (a, b) => a.offset - b.offset);

            var namespaces = new Dictionary<int, List<(int index, string str)>>();

            List<(int, string)> globalNS = [];
            namespaces[0] = globalNS;

            for (int i = 0; i < setMin; i++)
                globalNS.Add((i, stringTable[i]));

            if (setMax < ((1 << stringTable.Resolver.IndexBits) - 1))
            {
                for (int i = setOffsets[0]; i <= setMax; i++)
                    globalNS.Add((i, stringTable[i]));
            }

            for (int i = 0; i < sortedSets.Length - 1; i++)
            {
                var members = new List<(int, string)>();

                int startIndex = sortedSets[i].offset;
                int endIndex = sortedSets[i + 1].offset;

                for (int j = startIndex; j < endIndex; j++)
                    members.Add((j, stringTable[j]));

                namespaces[sortedSets[i].id] = members;
            }

            return namespaces;
        }
    }
}
