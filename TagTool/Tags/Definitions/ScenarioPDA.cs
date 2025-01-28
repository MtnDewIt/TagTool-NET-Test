using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "scenario_pda", Tag = "spda", Size = 0xC)]
    public class ScenarioPDA : TagStructure
    {
        public List<Scenario.PDADefinitionsBlock> PDA;
    }
}
