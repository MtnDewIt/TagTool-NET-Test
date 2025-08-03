using TagTool.Cache;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TagTool.Scripting
{
    public struct ScriptInfo : IList<ScriptInfo.ParameterInfo>
    {
        public HsType Type;
        public string Name;
        public List<ParameterInfo> Parameters;

        public int Count => Parameters.Count;
        public bool IsReadOnly => false;

        public ScriptInfo(HsType type) : this(type, "") { }

        public ScriptInfo(HsType type, string name) : this(type, name, new List<ParameterInfo>()) { }

        public ScriptInfo(HsType type, string name, IEnumerable<ParameterInfo> arguments)
        {
            Type = type;
            Name = name;
            Parameters = arguments.ToList();
        }

        public ParameterInfo this[int index] { get => Parameters[index]; set => Parameters[index] = value; }

        public int IndexOf(ParameterInfo item) => Parameters.IndexOf(item);
        public void Insert(int index, ParameterInfo item) => Parameters.Insert(index, item);
        public void RemoveAt(int index) => Parameters.RemoveAt(index);
        public void Add(ParameterInfo item) => Parameters.Add(item);
        public void Clear() => Parameters.Clear();
        public bool Contains(ParameterInfo item) => Parameters.Contains(item);
        public void CopyTo(ParameterInfo[] array, int arrayIndex) => Parameters.CopyTo(array, arrayIndex);
        public bool Remove(ParameterInfo item) => Parameters.Remove(item);
        public IEnumerator<ParameterInfo> GetEnumerator() => Parameters.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Parameters.GetEnumerator();

        public struct ParameterInfo
        {
            public HsType Type;
            public string Name;

            public ParameterInfo(HsType type) : this(type, "") { }

            public ParameterInfo(HsType type, string name)
            {
                Type = type;
                Name = name;
            }
        }
        public static int GetScriptExpressionDataLength(HsSyntaxNode expr)
        {
            switch (expr.Flags)
            {
                case HsSyntaxNodeFlags.Expression:
                    return ValueTypeSizes[expr.ValueType];

                default:
                    return 4;
            }
        }

        public static Dictionary<HsType, int> ValueTypeSizes { get; } = new Dictionary<HsType, int>
        {
            [HsType.Invalid] = 4,
            [HsType.Unparsed] = 0,
            [HsType.SpecialForm] = 0,
            [HsType.FunctionName] = 4,
            [HsType.Passthrough] = 0,
            [HsType.Void] = 4,
            [HsType.Boolean] = 1,
            [HsType.Real] = 4,
            [HsType.Short] = 2,
            [HsType.Long] = 4,
            [HsType.String] = 4,
            [HsType.Script] = 2,
            [HsType.StringId] = 4,
            [HsType.UnitSeatMapping] = 4,
            [HsType.TriggerVolume] = 2,
            [HsType.CutsceneFlag] = 2,
            [HsType.CutsceneCameraPoint] = 2,
            [HsType.CutsceneTitle] = 2,
            [HsType.CutsceneRecording] = 2,
            [HsType.DeviceGroup] = 4,
            [HsType.Ai] = 4,
            [HsType.AiCommandList] = 2,
            [HsType.AiCommandScript] = 2,
            [HsType.AiBehavior] = 2,
            [HsType.AiOrders] = 2,
            [HsType.AiLine] = 4,
            [HsType.StartingProfile] = 2,
            [HsType.Conversation] = 2,
            [HsType.Player] = 4,
            [HsType.ZoneSet] = 2,
            [HsType.DesignerZone] = 2,
            [HsType.PointReference] = 4,
            [HsType.Style] = 4,
            [HsType.ObjectList] = 4,
            [HsType.Folder] = 4,
            [HsType.Sound] = 4,
            [HsType.Effect] = 4,
            [HsType.Damage] = 4,
            [HsType.LoopingSound] = 4,
            [HsType.AnimationGraph] = 4,
            [HsType.DamageEffect] = 4,
            [HsType.ObjectDefinition] = 4,
            [HsType.Bitmap] = 4,
            [HsType.Shader] = 4,
            [HsType.RenderModel] = 4,
            [HsType.StructureDefinition] = 4,
            [HsType.LightmapDefinition] = 4,
            [HsType.CinematicDefinition] = 4,
            [HsType.CinematicSceneDefinition] = 4,
            [HsType.CinematicTransitionDefinition] = 4,
            [HsType.BinkDefinition] = 4,
            [HsType.CuiScreenDefinition] = 4,
            [HsType.AnyTag] = 4,
            [HsType.AnyTagNotResolving] = 4,
            [HsType.GameDifficulty] = 2,
            [HsType.Team] = 2,
            [HsType.MpTeam] = 2,
            [HsType.Controller] = 2,
            [HsType.ButtonPreset] = 2,
            [HsType.JoystickPreset] = 2,
            [HsType.PlayerColor] = 2,
            [HsType.PlayerModelChoice] = 2,
            [HsType.PlayerCharacterType] = 2,
            [HsType.VoiceOutputSetting] = 2,
            [HsType.VoiceMask] = 2,
            [HsType.SubtitleSetting] = 2,
            [HsType.ActorType] = 2,
            [HsType.ModelState] = 2,
            [HsType.Event] = 2,
            [HsType.CharacterPhysics] = 2,
            [HsType.PrimarySkull] = 2,
            [HsType.SecondarySkull] = 4,
            [HsType.Skull] = 4,
            [HsType.FiringPointEvaluator] = 4,
            [HsType.DamageRegion] = 4,
            [HsType.Object] = 4,
            [HsType.Unit] = 4,
            [HsType.Vehicle] = 4,
            [HsType.Weapon] = 4,
            [HsType.Device] = 4,
            [HsType.Scenery] = 4,
            [HsType.EffectScenery] = 4,
            [HsType.ObjectName] = 2,
            [HsType.UnitName] = 2,
            [HsType.VehicleName] = 2,
            [HsType.WeaponName] = 2,
            [HsType.DeviceName] = 2,
            [HsType.SceneryName] = 2,
            [HsType.EffectSceneryName] = 4,
            [HsType.CinematicLightprobe] = 4,
            [HsType.AnimationBudgetReference] = 4,
            [HsType.LoopingSoundBudgetReference] = 4,
            [HsType.SoundBudgetReference] = 4
        };
    }
}
