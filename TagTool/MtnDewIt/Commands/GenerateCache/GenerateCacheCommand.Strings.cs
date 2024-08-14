using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.Common;

namespace TagTool.MtnDewIt.Commands.GenerateCache 
{
    partial class GenerateCacheCommand : Command 
    {
        public void UpdateStringTable(StringTable stringTable) 
        {
            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\bin\ms23_strings.json");
            var ms23Strings = JsonConvert.DeserializeObject<List<string>>(jsonData);

            var startingIndex = 0x10DE;

            for (int i = stringTable.Count; i < startingIndex; i++) 
            {
                stringTable.Add(null);
            }

            foreach (var str in ms23Strings)
                stringTable.Add(str);
        }
    }
}