using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.Shaders.ShaderGenerator
{
    public static class GlobalMacroList
    {
        private static readonly List<HaloShaderGenerator.DirectX.D3D.SHADER_MACRO> MacroList = [];

        public static List<HaloShaderGenerator.DirectX.D3D.SHADER_MACRO> GetUserMacros() => MacroList;

        public static void AddUserMacro(string name, string definition)
        {
            if (!MacroList.Any(x => x.Name == name))
                MacroList.Add(new HaloShaderGenerator.DirectX.D3D.SHADER_MACRO { Name = name, Definition = definition });
        }

        public static void ClearUserMacros()
        {
            MacroList.Clear();
        }

        public static void RemoveUserMacro(string name)
        {
            for (int i = MacroList.Count - 1; i >= 0; i--)
            {
                if (MacroList[i].Name == name)
                    MacroList.RemoveAt(i);
            }
        }
    }
}
