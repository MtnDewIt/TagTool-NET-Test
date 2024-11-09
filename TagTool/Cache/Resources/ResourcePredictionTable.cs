using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Size = 0x3C)]
    public class ResourcePredictionTable : TagStructure 
    {
        public List<PredictionQuantum> PredictionQuanta;
        public List<PredictionAtom> PredictionAtoms;
        public List<PredictionMoleculeAtom> PredictionMoleculeAtoms;
        public List<PredictionMolecule> PredictionMolecules;
        public List<PredictionMoleculeKey> PredictionMoleculeKeys;

        [TagStructure(Size = 0x4)]
        public class PredictionQuantum : TagStructure
        {
            public DatumHandle InternalResourceHandle;
        }

        [TagStructure(Size = 0x8)]
        public class PredictionAtom : TagStructure
        {
            public ushort IndexSalt;
            public short PredictionQuantumCount;
            public int FirstPredictionQuantumIndex;
        }

        [TagStructure(Size = 0x4)]
        public class PredictionMoleculeAtom : TagStructure
        {
            public DatumHandle PredictionAtomHandle;
        }

        [TagStructure(Size = 0x8)]
        public class PredictionMolecule : TagStructure
        {
            public short PredictionAtomCount;
            public short FirstPredictionAtomIndex;
            public short PredictionQuantumCount;
            public short FirstPredictionQuantumIndex;
        }

        [TagStructure(Size = 0x18)]
        public class PredictionMoleculeKey : TagStructure
        {
            public CachedTag Owner;
            public int FirstValue;
            public int SecondValue;
        }
    }
}
