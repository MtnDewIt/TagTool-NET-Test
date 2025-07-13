using TagTool.Cache;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TagTool.Scripting
{
    public struct ScriptInfo : IList<ScriptInfo.ParameterInfo>
    {
        public HsType.HaloOnlineValue Type;
        public string Name;
        public List<ParameterInfo> Parameters;

        public int Count => Parameters.Count;
        public bool IsReadOnly => false;

        public ScriptInfo(HsType.HaloOnlineValue type) : this(type, "") { }

        public ScriptInfo(HsType.HaloOnlineValue type, string name) : this(type, name, new List<ParameterInfo>()) { }

        public ScriptInfo(HsType.HaloOnlineValue type, string name, IEnumerable<ParameterInfo> arguments)
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
            public HsType.HaloOnlineValue Type;
            public string Name;

            public ParameterInfo(HsType.HaloOnlineValue type) : this(type, "") { }

            public ParameterInfo(HsType.HaloOnlineValue type, string name)
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
                    return ValueTypeSizes[expr.ValueType.HaloOnline];

                default:
                    return 4;
            }
        }

        public static Dictionary<HsType.HaloOnlineValue, int> ValueTypeSizes { get; } = new Dictionary<HsType.HaloOnlineValue, int>
        {
            [HsType.HaloOnlineValue.Invalid] = 4,
            [HsType.HaloOnlineValue.Unparsed] = 0,
            [HsType.HaloOnlineValue.SpecialForm] = 0,
            [HsType.HaloOnlineValue.FunctionName] = 4,
            [HsType.HaloOnlineValue.Passthrough] = 0,
            [HsType.HaloOnlineValue.Void] = 4,
            [HsType.HaloOnlineValue.Boolean] = 1,
            [HsType.HaloOnlineValue.Real] = 4,
            [HsType.HaloOnlineValue.Short] = 2,
            [HsType.HaloOnlineValue.Long] = 4,
            [HsType.HaloOnlineValue.String] = 4,
            [HsType.HaloOnlineValue.Script] = 2,
            [HsType.HaloOnlineValue.StringId] = 4,
            [HsType.HaloOnlineValue.UnitSeatMapping] = 4,
            [HsType.HaloOnlineValue.TriggerVolume] = 2,
            [HsType.HaloOnlineValue.CutsceneFlag] = 2,
            [HsType.HaloOnlineValue.CutsceneCameraPoint] = 2,
            [HsType.HaloOnlineValue.CutsceneTitle] = 2,
            [HsType.HaloOnlineValue.CutsceneRecording] = 2,
            [HsType.HaloOnlineValue.DeviceGroup] = 4,
            [HsType.HaloOnlineValue.Ai] = 4,
            [HsType.HaloOnlineValue.AiCommandList] = 2,
            [HsType.HaloOnlineValue.AiCommandScript] = 2,
            [HsType.HaloOnlineValue.AiBehavior] = 2,
            [HsType.HaloOnlineValue.AiOrders] = 2,
            [HsType.HaloOnlineValue.AiLine] = 4,
            [HsType.HaloOnlineValue.StartingProfile] = 2,
            [HsType.HaloOnlineValue.Conversation] = 2,
            [HsType.HaloOnlineValue.ZoneSet] = 2,
            [HsType.HaloOnlineValue.DesignerZone] = 2,
            [HsType.HaloOnlineValue.PointReference] = 4,
            [HsType.HaloOnlineValue.Style] = 4,
            [HsType.HaloOnlineValue.ObjectList] = 4,
            [HsType.HaloOnlineValue.Folder] = 4,
            [HsType.HaloOnlineValue.Sound] = 4,
            [HsType.HaloOnlineValue.Effect] = 4,
            [HsType.HaloOnlineValue.Damage] = 4,
            [HsType.HaloOnlineValue.LoopingSound] = 4,
            [HsType.HaloOnlineValue.AnimationGraph] = 4,
            [HsType.HaloOnlineValue.DamageEffect] = 4,
            [HsType.HaloOnlineValue.ObjectDefinition] = 4,
            [HsType.HaloOnlineValue.Bitmap] = 4,
            [HsType.HaloOnlineValue.Shader] = 4,
            [HsType.HaloOnlineValue.RenderModel] = 4,
            [HsType.HaloOnlineValue.StructureDefinition] = 4,
            [HsType.HaloOnlineValue.LightmapDefinition] = 4,
            [HsType.HaloOnlineValue.CinematicDefinition] = 4,
            [HsType.HaloOnlineValue.CinematicSceneDefinition] = 4,
            [HsType.HaloOnlineValue.BinkDefinition] = 4,
            [HsType.HaloOnlineValue.AnyTag] = 4,
            [HsType.HaloOnlineValue.AnyTagNotResolving] = 4,
            [HsType.HaloOnlineValue.GameDifficulty] = 2,
            [HsType.HaloOnlineValue.Team] = 2,
            [HsType.HaloOnlineValue.MpTeam] = 2,
            [HsType.HaloOnlineValue.Controller] = 2,
            [HsType.HaloOnlineValue.ButtonPreset] = 2,
            [HsType.HaloOnlineValue.JoystickPreset] = 2,
            [HsType.HaloOnlineValue.PlayerCharacterType] = 2,
            [HsType.HaloOnlineValue.VoiceOutputSetting] = 2,
            [HsType.HaloOnlineValue.VoiceMask] = 2,
            [HsType.HaloOnlineValue.SubtitleSetting] = 2,
            [HsType.HaloOnlineValue.ActorType] = 2,
            [HsType.HaloOnlineValue.ModelState] = 2,
            [HsType.HaloOnlineValue.Event] = 2,
            [HsType.HaloOnlineValue.CharacterPhysics] = 2,
            [HsType.HaloOnlineValue.PrimarySkull] = 2,
            [HsType.HaloOnlineValue.SecondarySkull] = 4,
            [HsType.HaloOnlineValue.Object] = 4,
            [HsType.HaloOnlineValue.Unit] = 4,
            [HsType.HaloOnlineValue.Vehicle] = 4,
            [HsType.HaloOnlineValue.Weapon] = 4,
            [HsType.HaloOnlineValue.Device] = 4,
            [HsType.HaloOnlineValue.Scenery] = 4,
            [HsType.HaloOnlineValue.EffectScenery] = 4,
            [HsType.HaloOnlineValue.ObjectName] = 2,
            [HsType.HaloOnlineValue.UnitName] = 2,
            [HsType.HaloOnlineValue.VehicleName] = 2,
            [HsType.HaloOnlineValue.WeaponName] = 2,
            [HsType.HaloOnlineValue.DeviceName] = 2,
            [HsType.HaloOnlineValue.SceneryName] = 2,
            [HsType.HaloOnlineValue.EffectSceneryName] = 4,
            [HsType.HaloOnlineValue.CinematicLightprobe] = 4,
            [HsType.HaloOnlineValue.AnimationBudgetReference] = 4,
            [HsType.HaloOnlineValue.LoopingSoundBudgetReference] = 4,
            [HsType.HaloOnlineValue.SoundBudgetReference] = 4
        };
    }
}
