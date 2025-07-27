using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.Scripting;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        private void ConvertScripts(Stream cacheStream, Stream blamCacheStream, Scenario scnr, string tagName)
        {
            if (FlagIsSet(PortingFlags.Scripts))
            {
                foreach (var global in scnr.Globals)
                {
                    global.Type = ConvertHsType(global.Type);
                }

                foreach (var script in scnr.Scripts)
                {
                    script.ReturnType = ConvertHsType(script.ReturnType);

                    foreach (var parameter in script.Parameters)
                        parameter.Type = ConvertHsType(parameter.Type);
                }

                foreach (var expr in scnr.ScriptExpressions)
                {
                    ConvertScriptExpression(cacheStream, blamCacheStream, scnr, expr);
                }

                AdjustScripts(scnr, tagName);
            }
            else
            {
                scnr.Globals = new List<HsGlobal>();
                scnr.Scripts = new List<HsScript>();
                scnr.ScriptExpressions = new List<HsSyntaxNode>();
            }
        }

        private void ConvertScriptExpression(Stream cacheStream, Stream blamCacheStream, Scenario scnr, HsSyntaxNode expr)
        {
            if (expr.Opcode == 0xBABA)
                return;

            expr.ValueType = ConvertHsType(expr.ValueType);

            switch (expr.Flags)
            {
                case HsSyntaxNodeFlags.Expression:
                case HsSyntaxNodeFlags.Group:
                case HsSyntaxNodeFlags.GlobalsReference:
                case HsSyntaxNodeFlags.ParameterReference:
                    if (ScriptExpressionIsValue(expr))
                        ConvertScriptValueOpcode(expr);
                    else if (!ConvertScriptUsingPresets(cacheStream, scnr, expr))
                        ConvertScriptExpressionOpcode(scnr, expr);
                    break;

                case HsSyntaxNodeFlags.ScriptReference: // The opcode is the tagblock index of the script it uses. Don't convert opcode
                    break;

                default:
                    break;
            }

            ConvertScriptExpressionData(cacheStream, blamCacheStream, expr);
        }

        private bool ScriptExpressionIsValue(HsSyntaxNode expr)
        {
            switch (expr.Flags)
            {
                case HsSyntaxNodeFlags.ParameterReference:
                case HsSyntaxNodeFlags.GlobalsReference:
                    return true;

                case HsSyntaxNodeFlags.Expression:
                    if (expr.ValueType > HsType.Void)
                        return true;
                    else
                        return false;

                case HsSyntaxNodeFlags.ScriptReference: // The opcode is the tagblock index of the script it uses, so ignore
                case HsSyntaxNodeFlags.Group:
                    return false;

                default:
                    return false;
            }
        }

        private HsType ConvertHsType(HsType type)
        {
            if (type == HsType.PlayerColor)
            {
                Log.Warning($"{HsType.PlayerColor} not supported");
                return HsType.Invalid;
            }

            return type;
        }

        private void ConvertScriptValueOpcode(HsSyntaxNode expr)
        {
            if (expr.Opcode == 0xFFFF || expr.Opcode == 0xBABA || expr.Opcode == 0x0000)
                return;

            switch (expr.Flags)
            {
                case HsSyntaxNodeFlags.Expression:
                case HsSyntaxNodeFlags.Group:
                case HsSyntaxNodeFlags.GlobalsReference:
                case HsSyntaxNodeFlags.ParameterReference:
                    break;

                case HsSyntaxNodeFlags.ScriptReference: // The opcode is the tagblock index of the script it uses. Don't convert opcode
                    return;

                default:
                    return;
            }

            // Some script expressions use opcode as a script reference. Only continue if it is a reference
            if (!BlamCache.ScriptDefinitions.ValueTypes.ContainsKey(expr.Opcode))
            {
                Log.Error($"not in {BlamCache.Version} opcode table 0x{expr.Opcode:X3}.");
                return;
            }

            var blamValueTypeName = BlamCache.ScriptDefinitions.ValueTypes[expr.Opcode];

            foreach (var valueType in CacheContext.ScriptDefinitions.ValueTypes)
            {
                if (valueType.Value == blamValueTypeName)
                {
                    expr.Opcode = (ushort)valueType.Key;
                    break;
                }
            }
        }

        private void ConvertScriptExpressionUnsupportedOpcode(HsSyntaxNode expr)
        {
            if (expr.Opcode == 0xBABA || expr.Opcode == 0xCDCD)
                return;

            expr.Opcode = 0x000; // begin
        }

        private void ConvertScriptExpressionOpcode(Scenario scnr, HsSyntaxNode expr)
        {
            switch (expr.Flags)
            {
                case HsSyntaxNodeFlags.Expression:
                    if (expr.Flags == HsSyntaxNodeFlags.ScriptReference)
                        return;

                    // If the previous scriptExpr is a scriptRef, don't convert. The opcode is the script reference. They always come in pairs.
                    if (scnr.ScriptExpressions[scnr.ScriptExpressions.IndexOf(expr) - 1].Flags == HsSyntaxNodeFlags.ScriptReference)
                        return;

                    break;

                case HsSyntaxNodeFlags.Group:
                    break;

                case HsSyntaxNodeFlags.ScriptReference: // The opcode is the tagblock index of the script it uses. Don't convert opcode
                case HsSyntaxNodeFlags.GlobalsReference: // The opcode is the tagblock index of the global it uses. Don't convert opcode
                case HsSyntaxNodeFlags.ParameterReference: // Probably as above
                    return;

                default:
                    return;
            }

            if (!BlamCache.ScriptDefinitions.Scripts.ContainsKey(expr.Opcode))
            {
                Log.Error($"not in {BlamCache.Version} opcode table: 0x{expr.Opcode:X3}. (ConvertScriptExpressionOpcode)");
                return;
            }

            var blamScript = BlamCache.ScriptDefinitions.Scripts[expr.Opcode];

            bool match;

            foreach (var entry in CacheContext.ScriptDefinitions.Scripts)
            {
                var newOpcode = entry.Key;
                var newScript = entry.Value;

                if (newScript.Name != blamScript.Name)
                    continue;

                if (newScript.Parameters.Count != blamScript.Parameters.Count)
                    continue;

                match = true;

                for (var k = 0; k < newScript.Parameters.Count; k++)
                {
                    if (newScript.Parameters[k].Type != blamScript.Parameters[k].Type)
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    expr.Opcode = (ushort)newOpcode;
                    return;
                }
            }

            //
            // If no match was found, the opcode is currently unsupported.
            //

            Log.Warning($"No equivalent script op was found for '{BlamCache.ScriptDefinitions.Scripts[expr.Opcode].Name}' (0x{expr.Opcode:X3}, expr {scnr.ScriptExpressions.IndexOf(expr)})");

            ConvertScriptExpressionUnsupportedOpcode(expr);
        }

        private void ConvertScriptExpressionData(Stream cacheStream, Stream blamCacheStream, HsSyntaxNode expr)
        {
            if (expr.Flags == HsSyntaxNodeFlags.Expression)
                switch (expr.ValueType)
                {
                    case HsType.Sound:
                    case HsType.Effect:
                    case HsType.Damage:
                    case HsType.LoopingSound:
                    case HsType.AnimationGraph:
                    case HsType.DamageEffect:
                    case HsType.ObjectDefinition:
                    case HsType.Bitmap:
                    case HsType.Shader:
                    case HsType.RenderModel:
                    case HsType.StructureDefinition:
                    case HsType.LightmapDefinition:
                    case HsType.CinematicDefinition:
                    case HsType.CinematicSceneDefinition:
                    case HsType.BinkDefinition:
                    case HsType.AnyTag:
                    case HsType.AnyTagNotResolving:
                        ConvertScriptTagReferenceExpressionData(cacheStream, blamCacheStream, expr);
                        return;

                    case HsType.AiLine when BitConverter.ToInt32(expr.Data, 0) != -1:
                    case HsType.StringId:
                        ConvertScriptStringIdExpressionData(cacheStream, blamCacheStream, expr);
                        return;

                    default:
                        break;
                }

            var dataSize = 4;

            switch (expr.Flags)
            {
                case HsSyntaxNodeFlags.Expression:
                    switch (expr.ValueType)
                    {
                        case HsType.Object:
                        case HsType.Unit:
                        case HsType.Vehicle:
                        case HsType.Weapon:
                        case HsType.Device:
                        case HsType.Scenery:
                        case HsType.EffectScenery:
                            dataSize = 2; // definitely not 4
                            break;

                        case HsType.Ai: // int
                            break;

                        default:
                            dataSize = ScriptInfo.GetScriptExpressionDataLength(expr);
                            break;
                    }
                    break;

                case HsSyntaxNodeFlags.GlobalsReference:
                    if (BlamCache.Version == CacheVersion.Halo3Retail)
                    {
                        dataSize = ScriptInfo.GetScriptExpressionDataLength(expr);
                    }
                    else if (BlamCache.Version == CacheVersion.Halo3ODST)
                    {
                        switch (expr.ValueType)
                        {
                            case HsType.Long:
                                dataSize = 2; // definitely not 4
                                break;
                            default:
                                dataSize = ScriptInfo.GetScriptExpressionDataLength(expr);
                                break;
                        }
                    }
                    break;

                default:
                    dataSize = ScriptInfo.GetScriptExpressionDataLength(expr);
                    break;
            }

#if DEBUG
            if (expr.Flags == HsSyntaxNodeFlags.Expression && BitConverter.ToInt32(expr.Data, 0) != -1)
            {
                //
                // Breakpoint any case statement below to examine different types of "object" expression data
                //

                switch (expr.ValueType)
                {
                    case HsType.Object: break;
                    case HsType.Unit: break;
                    case HsType.Vehicle: break;
                    case HsType.Weapon: break;
                    case HsType.Device: break;
                    case HsType.Scenery: break;
                    case HsType.EffectScenery: break;
                }
            }
#endif

            if (!CacheVersionDetection.IsLittleEndian(BlamCache.Version, BlamCache.Platform))
                Array.Reverse(expr.Data, 0, dataSize);

            if (expr.Flags == HsSyntaxNodeFlags.GlobalsReference)
            {
                if (expr.Data[2] == 0xFF && expr.Data[3] == 0xFF)
                {
                    var opcode = BitConverter.ToUInt16(expr.Data, 0) & ~0x8000;
                    var name = BlamCache.ScriptDefinitions.Globals[opcode];
                    opcode = CacheContext.ScriptDefinitions.Globals.First(p => p.Value == name).Key | 0x8000;
                    var bytes = BitConverter.GetBytes(opcode);
                    expr.Data[0] = bytes[0];
                    expr.Data[1] = bytes[1];
                }
            }
            else if (expr.Flags == HsSyntaxNodeFlags.Expression && expr.ValueType == HsType.Ai)
            {
                var value = BitConverter.ToUInt32(expr.Data, 0);

                if (value != uint.MaxValue && BlamCache.Version == CacheVersion.Halo3Retail)
                {
                    var aiValueType = (value >> 29) & 0x7;
                    var squadIndex = (value >> 16) & 0x1FFF;
                    var taskIndex = (value >> 16) & 0x1FFF;
                    var fireTeamIndex = (value >> 8) & 0xFF;
                    var spawnPointIndex = value & 0xFF;

                    switch (aiValueType)
                    {
                        case 1: // squad index
                        case 2: // squad group index
                        case 3: // actor datum_index
                            value = (uint)(((aiValueType & 0x7) << 29) | (value & 0xFFFF));
                            break;

                        case 4: // starting location
                            value = (uint)(((aiValueType & 0x7) << 29) | ((squadIndex & 0x1FFF) << 16) | (GetSpawnPointIndex(squadIndex, fireTeamIndex, spawnPointIndex) & 0xFF));
                            break;

                        case 5: // objective task
                            aiValueType++; // odst added spawn_formation
                            value = (uint)(((aiValueType & 0x7) << 29) | ((taskIndex & 0x1FFF) << 16) | (value & 0xFFFF));
                            break;

                        default:
                            throw new NotSupportedException($"0x{value:X8}");
                    }

                    expr.Data = BitConverter.GetBytes(value);
                }
            }
        }

        private uint GetSpawnPointIndex(uint squadIndex, uint fireTeamIndex, uint spawnPointIndex)
        {
            var prevSpawnPoints = 0;

            for (var i = 0; i < fireTeamIndex; i++)
                prevSpawnPoints += CurrentScenario.Squads[(int)squadIndex].Fireteams[i].StartingLocations.Count;

            return (uint)(prevSpawnPoints + spawnPointIndex);
        }

        private void ConvertScriptTagReferenceExpressionData(Stream cacheStream, Stream blamCacheStream, HsSyntaxNode expr)
        {
            if (!FlagIsSet(PortingFlags.Recursive))
                return;

            uint tagIndex;
            if (CacheVersionDetection.IsLittleEndian(BlamCache.Version, BlamCache.Platform))
                tagIndex = BitConverter.ToUInt32(expr.Data, 0);
            else
                tagIndex = BitConverter.ToUInt32(expr.Data.Reverse().ToArray(), 0);

            var tag = ConvertTag(cacheStream, blamCacheStream, BlamCache.TagCache.GetTag(tagIndex));

            if (tag == null)
                return;

            expr.Data = BitConverter.GetBytes(tag?.Index ?? -1).ToArray();
        }

        private void ConvertScriptStringIdExpressionData(Stream cacheStream, Stream blamCacheStream, HsSyntaxNode expr)
        {
            uint blamStringId;
            if (CacheVersionDetection.IsLittleEndian(BlamCache.Version, BlamCache.Platform))
                blamStringId = BitConverter.ToUInt32(expr.Data, 0);
            else
                blamStringId = BitConverter.ToUInt32(expr.Data.Reverse().ToArray(), 0);

            var value = BlamCache.StringTable.GetString(new StringId(blamStringId));

            if (value == null)
                return;

            if (!CacheContext.StringTable.Contains(value))
                ConvertStringId(new StringId(blamStringId));

            var edStringId = CacheContext.StringTable.GetStringId(value);
            expr.Data = BitConverter.GetBytes(edStringId.Value).ToArray();
        }

        private bool ConvertScriptUsingPresets(Stream cacheStream, Scenario scnr, HsSyntaxNode expr)
        {
            // Return false to convert normally.

            if (!BlamCache.ScriptDefinitions.Scripts.ContainsKey(expr.Opcode))
                return false;

            string opName = BlamCache.ScriptDefinitions.Scripts[expr.Opcode].Name;

            if (BlamCache.Platform == CachePlatform.MCC)
            {
                switch (opName)
                {
                    case "mp_wake_script":
                        expr.Opcode = 0x6A7; // -> mp_wake_script
                        UpdateMpWakeScript(cacheStream, scnr, expr);
                        return true;
                }
            }

            if (BlamCache.Version == CacheVersion.Halo3Retail)
            {
                switch (opName)
                {
                    // changed from short -> primary_skull/secondary_skull in odst. fine to leave as short
                    case "campaign_metagame_award_primary_skull":
                        expr.Opcode = 0x1E5;
                        return true;
                    case "campaign_metagame_award_secondary_skull":
                        expr.Opcode = 0x1E6;
                        return true;

                    case "cinematic_object_get_unit":
                    case "cinematic_object_get_scenery":
                    case "cinematic_object_get_effect_scenery":
                        expr.Opcode = 0x391; // -> cinematic_object_get
                        return true;

                    case "cinematic_scripting_create_object":
                        expr.Opcode = 0x6A2; // -> cinematic_scripting_create_object_legacy
                        return true;
                    case "cinematic_scripting_start_animation":
                        expr.Opcode = 0x6A1; // -> cinematic_scripting_start_animation_legacy
                        return true;
                    case "cinematic_scripting_destroy_object":
                        expr.Opcode = 0x6A6; // -> cinematic_scripting_destroy_object_legacy
                        return true;
                    case "cinematic_scripting_create_and_animate_object":
                        expr.Opcode = 0x6A3; // -> cinematic_scripting_create_and_animate_object_legacy
                        return true;
                    case "cinematic_scripting_create_and_animate_cinematic_object":
                        expr.Opcode = 0x6A5; // -> cinematic_scripting_create_and_animate_cinematic_object_legacy
                        return true;
                    case "cinematic_scripting_create_and_animate_object_no_animation":
                        expr.Opcode = 0x6A4; // -> cinematic_scripting_create_and_animate_object_no_animation_legacy
                        return true;

                    case "player_action_test_cinematic_skip":
                        expr.Opcode = 0x2F5; // player_action_test_jump
                        return true;

                    case "texture_camera_set_aspect_ratio":
                        expr.Opcode = 0x0B9;
                        // Change the player appearance aspect ratio
                        if (scnr.MapId == 0x10231971 && // mainmenu map id
                            expr.Flags == HsSyntaxNodeFlags.Group &&
                            expr.ValueType == HsType.Void)
                        {
                            var exprIndex = scnr.ScriptExpressions.IndexOf(expr) + 1;
                            for (var n = 1; n < 2; n++)
                                exprIndex = scnr.ScriptExpressions[exprIndex].NextExpressionHandle.Index;

                            var expr2 = scnr.ScriptExpressions[exprIndex];
                            expr2.Data = BitConverter.GetBytes(1.777f).Reverse().ToArray();
                        }
                        return true;

                    case "unit_add_equipment":
                        expr.Opcode = 0x136; // -> unit_add_equipment
                        UpdateUnitAddEquipmentScript(cacheStream, scnr, expr);
                        return true;

                    case "vehicle_test_seat_list":
                        if (Options.EnableH3VehicleTestSeat)
                            expr.Opcode = 0x6A9; // -> vehicle_test_seat_list_legacy
                        else
                        {
                            expr.Opcode = 0x114; // -> vehicle_test_seat_unit_list
                            UpdateAiTestSeat(cacheStream, scnr, expr);
                        }
                        return true;

                    case "vehicle_test_seat": // 
                        if (Options.EnableH3VehicleTestSeat)
                            expr.Opcode = 0x6AA; // -> vehicle_test_seat_legacy
                        else
                        {
                            expr.Opcode = 0x115; // -> vehicle_test_seat_unit
                            UpdateAiTestSeat(cacheStream, scnr, expr);
                        }
                        return true;
                }
            }

            return false;
        }

        private void UpdateUnitAddEquipmentScript(Stream cacheStream, Scenario scnr, HsSyntaxNode expr)
        {
            if (BlamCache.Version == CacheVersion.Halo3Retail)
            {
                var exprIndex = scnr.ScriptExpressions.IndexOf(expr);
                var profileExpr = scnr.ScriptExpressions[exprIndex + 3]; // <StartingProfile> parameter

                if (profileExpr.StringAddress != 0)
                {
                    if (profileExpr.ValueType != HsType.StartingProfile)
                        return;

                    using (var scriptStringStream = new MemoryStream(scnr.ScriptStrings))
                    using (var scriptStringReader = new BinaryReader(scriptStringStream))
                    {
                        var profileName = "";
                        scriptStringReader.BaseStream.Position = profileExpr.StringAddress;
                        for (char c; (c = scriptStringReader.ReadChar()) != 0x00; profileName += c) ;

                        var startingProfileIndex = scnr.PlayerStartingProfile.FindIndex(sp => sp.Name == profileName);

                        if (startingProfileIndex == -1)
                        {
                            Log.Warning($"StartingProfile reference could not be converted {profileName}");
                            return;
                        }

                        profileExpr.ValueType = HsType.StartingProfile;
                        profileExpr.Data = new byte[] { (byte)((startingProfileIndex >> 8)), (byte)(startingProfileIndex & 0xFF), 0xFF, 0xFF };
                        return;
                    }
                }
            }
        }

        private void UpdateMpWakeScript(Stream cacheStream, Scenario scnr, HsSyntaxNode expr)
        {
            var exprIndex = scnr.ScriptExpressions.IndexOf(expr) + 1;

            var stringExpr = scnr.ScriptExpressions[exprIndex]; // <string> parameter

            if (stringExpr.StringAddress != 0)
            {
                using (var scriptStringStream = new MemoryStream(scnr.ScriptStrings))
                using (var scriptStringReader = new BinaryReader(scriptStringStream))
                {
                    var scriptName = "";
                    scriptStringReader.BaseStream.Position = stringExpr.StringAddress;
                    for (char c; (c = scriptStringReader.ReadChar()) != 0x00; scriptName += c) ;

                    for (var i = 0; i < scnr.Scripts.Count; i++)
                    {
                        var script = scnr.Scripts[i];
                        if (scriptName == script.ScriptName)
                        {

                            stringExpr.ValueType = HsType.Script;
                            stringExpr.Data = BitConverter.GetBytes(i).ToArray();
                            return;
                        }
                    }
                }
            }
        }

        [Obsolete("Will no longer be needed")]
        private void UpdateAiTestSeat(Stream cacheStream, Scenario scnr, HsSyntaxNode expr)
        {
            if (expr.Flags != HsSyntaxNodeFlags.Group)
                return;

            var exprIndex = scnr.ScriptExpressions.IndexOf(expr) + 1;
            for (var n = 1; n < 2; n++)
                exprIndex = scnr.ScriptExpressions[exprIndex].NextExpressionHandle.Index;

            var vehicleExpr = scnr.ScriptExpressions[exprIndex]; // <vehicle> parameter
            var seatMappingExpr = scnr.ScriptExpressions[vehicleExpr.NextExpressionHandle.Index]; // <string_id> parameter

            StringId seatMappingStringId;
            if (CacheVersionDetection.IsLittleEndian(BlamCache.Version, BlamCache.Platform))
                seatMappingStringId = new StringId(BitConverter.ToUInt32(seatMappingExpr.Data, 0));
            else
                seatMappingStringId = new StringId(BitConverter.ToUInt32(seatMappingExpr.Data.Reverse().ToArray(), 0));

            var seatMappingString = BlamCache.StringTable.GetString(seatMappingStringId);
            var seatMappingIndex = (int)-1;

            if (vehicleExpr.Flags == HsSyntaxNodeFlags.Group &&
                seatMappingStringId != StringId.Invalid)
            {
                if (BlamCache.ScriptDefinitions.Scripts[vehicleExpr.Opcode].Name == "ai_vehicle_get_from_starting_location")
                {
                    var expr3 = scnr.ScriptExpressions[++exprIndex]; // function name
                    var expr4 = scnr.ScriptExpressions[expr3.NextExpressionHandle.Index]; // <ai> parameter

                    uint value;
                    if (CacheVersionDetection.IsLittleEndian(BlamCache.Version, BlamCache.Platform))
                        value = BitConverter.ToUInt32(expr4.Data.ToArray(), 0);
                    else
                        value = BitConverter.ToUInt32(expr4.Data.Reverse().ToArray(), 0);

                    if (value != uint.MaxValue)
                    {
                        var squadIndex = (value >> 16) & 0x1FFF;
                        var fireTeamIndex = (value >> 8) & 0xFF;

                        var fireTeam = scnr.Squads[(int)squadIndex].Fireteams[(int)fireTeamIndex];

                        var unitInstance = scnr.VehiclePalette[fireTeam.VehicleTypeIndex].Object;

                        if (unitInstance.Index == -1)
                        {
                            Log.Warning($"Unit tag reference invalid in script in UpdateAiTestSeat! squads index {squadIndex} fireteam index {fireTeamIndex}");
                            return;
                        }

                        var unitDefinition = (Unit)CacheContext.Deserialize<Vehicle>(cacheStream, unitInstance);

                        var variantName = CacheContext.StringTable.GetString(unitDefinition.DefaultModelVariant);

                        if (fireTeam.VehicleVariant != StringId.Invalid)
                            variantName = CacheContext.StringTable.GetString(fireTeam.VehicleVariant);

                        if (unitDefinition.Model.Index == -1)
                        {
                            Log.Warning($"Unit model tag reference invalid in UpdateAiTestSeat! Unit {unitInstance.Name}");
                            return;
                        }

                        var modelDefinition = CacheContext.Deserialize<Model>(cacheStream, unitDefinition.Model);
                        var modelVariant = default(Model.Variant);

                        foreach (var variant in modelDefinition.Variants)
                        {
                            if (variantName == CacheContext.StringTable.GetString(variant.Name))
                            {
                                modelVariant = variant;
                                break;
                            }
                        }

                        var seats1 = (Scenario.UnitSeatFlags)(0);
                        var seats2 = (Scenario.UnitSeatFlags)(0);

                        for (var seatIndex = 0; seatIndex < unitDefinition.Seats.Count; seatIndex++)
                        {
                            var seat = unitDefinition.Seats[seatIndex];
                            var seatName = CacheContext.StringTable.GetString(seat.Label);

                            if (seatMappingString == seatName)
                            {
                                if (seatIndex < 32)
                                    seats1 = (Scenario.UnitSeatFlags)(1 << seatIndex);
                                else
                                    seats2 = (Scenario.UnitSeatFlags)(1 << (seatIndex - 32));
                                break;
                            }
                        }

                        if (seats1 == Scenario.UnitSeatFlags.None && seats2 == Scenario.UnitSeatFlags.None)
                        {
                            foreach (var obj in modelVariant.Objects)
                            {
                                if (obj.ChildObject == null || !obj.ChildObject.IsInGroup("unit"))
                                    continue;

                                var definition = (Unit)CacheContext.Deserialize(cacheStream, obj.ChildObject);

                                for (var seatIndex = 0; seatIndex < definition.Seats.Count; seatIndex++)
                                {
                                    var seat = definition.Seats[seatIndex];
                                    var seatName = CacheContext.StringTable.GetString(seat.Label);

                                    if (seatMappingString == seatName)
                                    {
                                        if (seatIndex < 32)
                                            seats1 = (Scenario.UnitSeatFlags)(1 << seatIndex);
                                        else
                                            seats2 = (Scenario.UnitSeatFlags)(1 << (seatIndex - 32));
                                        break;
                                    }
                                }

                                if (seats1 != Scenario.UnitSeatFlags.None || seats2 != Scenario.UnitSeatFlags.None)
                                {
                                    unitInstance = obj.ChildObject;
                                    unitDefinition = definition;
                                    break;
                                }
                            }
                        }

                        if (seats1 == Scenario.UnitSeatFlags.None && seats2 == Scenario.UnitSeatFlags.None)
                        {
                            for (var i = 0; i < unitDefinition.Seats.Count; i++)
                            {
                                if (i < 32)
                                    seats1 |= (Scenario.UnitSeatFlags)(1 << i);
                                else
                                    seats2 |= (Scenario.UnitSeatFlags)(1 << (i - 32));
                            }
                        }

                        for (var mappingIndex = 0; mappingIndex < scnr.UnitSeatsMapping.Count; mappingIndex++)
                        {
                            var mapping = scnr.UnitSeatsMapping[mappingIndex];

                            if (mapping.Unit == unitInstance && mapping.Seats1 == seats1 && mapping.Seats2 == seats2)
                            {
                                seatMappingIndex = mappingIndex;
                                break;
                            }
                        }

                        if (seatMappingIndex == -1)
                        {
                            seatMappingIndex = scnr.UnitSeatsMapping.Count;

                            scnr.UnitSeatsMapping.Add(new Scenario.UnitSeatsMappingBlock
                            {
                                Unit = unitInstance,
                                Seats1 = seats1,
                                Seats2 = seats2
                            });
                        }
                    }
                }
            }

            seatMappingExpr.Opcode = 0x00C; // -> unit_seat_mapping
            seatMappingExpr.ValueType = HsType.UnitSeatMapping;
            seatMappingExpr.Data = BitConverter.GetBytes((seatMappingIndex & ushort.MaxValue) | (1 << 16)).Reverse().ToArray();
            //all four bytes need to be FF for the argument to be "none"
            if (seatMappingStringId == StringId.Invalid)
                seatMappingExpr.Data = BitConverter.GetBytes(-1);
        }

        [Obsolete("This should be removed, pending dll fixes")]
        private void AdjustScripts(Scenario scnr, string tagName)
        {
            // Disable for mcc as it's entirely incorrect
            if (BlamCache.Platform == CachePlatform.MCC)
                return;

            var mapName = tagName.Split("\\".ToCharArray()).Last();

            if (mapName == "mainmenu" && BlamCache.Version == CacheVersion.Halo3ODST)
                mapName = "mainmenu_odst";

            if (!DisabledScriptsString.ContainsKey(mapName))
                return;

            foreach (var line in DisabledScriptsString[mapName])
            {
                var items = line.Split(",".ToCharArray());

                int scriptIndex = Convert.ToInt32(items[0]);

                uint.TryParse(items[2], NumberStyles.HexNumber, null, out uint NextExpressionHandle);
                ushort.TryParse(items[3], NumberStyles.HexNumber, null, out ushort Opcode);
                byte.TryParse(items[4].Substring(0, 2), NumberStyles.HexNumber, null, out byte data0);
                byte.TryParse(items[4].Substring(2, 2), NumberStyles.HexNumber, null, out byte data1);
                byte.TryParse(items[4].Substring(4, 2), NumberStyles.HexNumber, null, out byte data2);
                byte.TryParse(items[4].Substring(6, 2), NumberStyles.HexNumber, null, out byte data3);

                scnr.ScriptExpressions[scriptIndex].NextExpressionHandle = new DatumHandle(NextExpressionHandle);
                scnr.ScriptExpressions[scriptIndex].Opcode = Opcode;
                scnr.ScriptExpressions[scriptIndex].Data[0] = data0;
                scnr.ScriptExpressions[scriptIndex].Data[1] = data1;
                scnr.ScriptExpressions[scriptIndex].Data[2] = data2;
                scnr.ScriptExpressions[scriptIndex].Data[3] = data3;
                scnr.ScriptExpressions[scriptIndex].Flags = (HsSyntaxNodeFlags)Enum.Parse(typeof(HsSyntaxNodeFlags), items[5]);
            }
        }

        [Obsolete("This should be removed, pending dll fixes")]
        private static Dictionary<string, List<string>> DisabledScriptsString = new Dictionary<string, List<string>>
        {
            // Format: Script expression tagblock index (dec), expression handle (salt + tagblock index), next expression handle (salt + tagblock index), opcode, data, 
            // expression type, value type, script expression name, original value, comment
            // Ideally this should use a dictionary with a list of script expressions per map name. I'm using a simple text format as this is how I dump scripts and modify them currently.

            ["mainmenu_odst"] = new List<string>
            {
                "00001043,E7860413,E79B0428,0112,140487E7,Group,Void,unit_enable_vision_mode, //default:E78B0418",
                "00001064,E79B0428,E7AD043A,0009,29049CE7,ScriptReference,Void,, //default:E79D042A",
                "00001328,E8A30530,E8B80545,0112,3105A4E8,Group,Void,unit_enable_vision_mode, //default:E8A80535",
                "00001572,E9970624,FFFFFFFF,0000,00000000,Expression,FunctionName,begin, //default:E9790606",
            },

            ["sc110"] = new List<string>
            {
                "00002188,EBFF088C,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// EBE1086E disable pda_breadcrumbs",
                "00018320,AB044790,AA6446F0,0000,00000000,Expression,FunctionName,begin,// AA4046CC disable waypoints temp",

                // autoremove:
                "00000892,E6EF037C,E6F50382,0016,00000000,Expression,FunctionName,// E6F0037D was pointing at E6F0037D",
                "00001468,E92F05BC,E93805C5,03F4,BD0530E9,Group,Void,// E93405C1 was pointing at E93405C1",
                "00001500,E94F05DC,FFFFFFFF,03F4,DD0550E9,Group,Void,// E95405E1 was pointing at E95405E1",
                "00001659,E9EE067B,EA030690,0112,7C06EFE9,Group,Void,// E9FF068C was pointing at E9FF068C",
                "00001680,EA030690,EA1506A2,0012,910604EA,ScriptReference,Void,// EA11069E was pointing at EA11069E",
                "00001944,EB0B0798,EB2007AD,0112,99070CEB,Group,Void,// EB1C07A9 was pointing at EB1C07A9",
                "00002164,EBE70874,EBFC0889,0000,00000000,Expression,FunctionName,// EBF70884 was pointing at EBF70884",
                "00005201,F7C41451,F7A81435,0000,00000000,Expression,FunctionName,// F7A2142F was pointing at F7A2142F",
                "00005173,F7A81435,FFFFFFFF,0014,3614A9F7,Group,Void,// F7BD144A was pointing at F7BD144A",
                "00018193,AA854711,AAA0472C,0627,124786AA,Group,Void,// AA9B4727 was pointing at AA9B4727",
                "00023201,BE155AA1,BE1B5AA7,0014,A25A16BE,Group,Void,// BE185AA4 was pointing at BE185AA4",
            },

            ["c200"] = new List<string>
            {
                "00000293,E4980125,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// E4860113",
                "00000482,E55501E2,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// E52F01BC",
                "00000532,E5870214,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// E56201EF",
                "00000603,E5CE025B,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// E5970224",
                "00000693,E62802B5,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// E5E1026E",
                "00000802,E6950322,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// E63E02CB",
                "00000852,E6C70354,E6D0035D,03F4,5503C8E6,Group,Void,sound_impulse_start,// E6CC0359",
                "00000884,E6E70374,FFFFFFFF,03F4,7503E8E6,Group,Void,sound_impulse_start,// E6EC0379",
                "00001043,E7860413,E79B0428,0112,140487E7,Group,Void,unit_enable_vision_mode,// E78B0418",
                "00001064,E79B0428,E7AD043A,0009,29049CE7,ScriptReference,Void,,// E79D042A",
                "00001328,E8A30530,E8B80545,0112,3105A4E8,Group,Void,unit_enable_vision_mode,// E8A80535",
                "00001572,E9970624,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// E9790606"
            },

            ["sc140"] = new List<string>
            {
                "00018790,ACDA4966,ACDB4967,0044,70010000,GlobalsReference,Vehicle,Value,//makes phantom fill up, allows level to finish",
                "00025501,C711639D,FFFFFFFF,0006,0000003C,Expression,Real,real,value," // convert default near_clip value (0.04 -> 0.0078125)
            },

            ["h100"] = new List<string>
            {
                "00016022,A20A3E96,A21F3EAB,0014,973E0BA2,Group,Void,sleep,", //get rid of f_l100_look_training
                "00017763,A8D74563,A94545D1,03EA,6445D8A8,Group,Void,game_save_cancel,", //get rid of all pda training
                "00016088,A24C3ED8,A2653EF1,0000,00000000,Expression,FunctionName,begin,", //get rid of health and vision training
            },

            ["l300"] = new List<string>
            {
                "00000891,E6EE037B,E6F50382,0016,7C03EFE6,Group,Void,sleep_until,// E6F60383",
                "00001060,E7970424,E7A50432,030F,250498E7,Group,Void,unit_action_test_reset,// E79C0429",
                "00001111,E7CA0457,E7D80465,030F,5804CBE7,Group,Void,unit_action_test_reset,// E7CF045C",
                "00001125,E7D80465,E7E0046D,0667,6604D9E7,Group,Void,chud_show_navpoint,// FFFFFFFF",
                "00001164,E7FF048C,E80D049A,030F,8D0400E8,Group,Void,unit_action_test_reset,// E8040491",
                "00001178,E80D049A,E81F04AC,0000,9B040EE8,Group,Void,begin,// FFFFFFFF",
                "00001238,E84904D6,E85704E4,030F,D7044AE8,Group,Void,unit_action_test_reset,// E84E04DB",
                "00001252,E85704E4,E87104FE,0000,E50458E8,Group,Void,begin,// FFFFFFFF",
                "00001331,E8A60533,E8B40541,030F,3405A7E8,Group,Void,unit_action_test_reset,// E8AB0538",
                "00001345,E8B40541,E8D60563,0000,4205B5E8,Group,Void,begin,// FFFFFFFF",
                "00001468,E92F05BC,E93805C5,03F4,BD0530E9,Group,Void,sound_impulse_start,// E93405C1",
                "00001500,E94F05DC,FFFFFFFF,03F4,DD0550E9,Group,Void,sound_impulse_start,// E95405E1",
                "00001659,E9EE067B,EA030690,0112,7C06EFE9,Group,Void,unit_enable_vision_mode,// E9F30680",
                "00001680,EA030690,EA1506A2,0012,910604EA,ScriptReference,Void,,// EA050692",
                "00001944,EB0B0798,EB2007AD,0112,99070CEB,Group,Void,unit_enable_vision_mode,// EB10079D",
                "00002188,EBFF088C,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// EBE1086E",
                "00005201,F7C41451,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// F7A2142F",
                "00020425,B33D4FC9,B3494FD5,0004,CA4F3EB3,Group,Void,set,// B3434FCF",
                "00020521,B39D5029,B3A75033,0169,2A509EB3,Group,Void,ai_cannot_die,// B3A1502D",
                "00020550,B3BA5046,B3C65052,0004,4750BBB3,Group,Void,set,// B3C0504C",
                "00020646,B41A50A6,B42450B0,0169,A7501BB4,Group,Void,ai_cannot_die,// B41E50AA",
                "00020675,B43750C3,B44350CF,0004,C45038B4,Group,Void,set,// B43D50C9",
                "00020771,B4975123,B4A1512D,0169,245198B4,Group,Void,ai_cannot_die,// B49B5127",
                "00020800,B4B45140,B4C0514C,0004,4151B5B4,Group,Void,set,// B4BA5146",
                "00020896,B51451A0,B51E51AA,0169,A15115B5,Group,Void,ai_cannot_die,// B51851A4",
                "00020925,B53151BD,B53D51C9,0004,BE5132B5,Group,Void,set,// B53751C3",
                "00021021,B591521D,B59B5227,0169,1E5292B5,Group,Void,ai_cannot_die,// B5955221",
                "00021050,B5AE523A,B5BA5246,0004,3B52AFB5,Group,Void,set,// B5B45240",
                "00021146,B60E529A,B61852A4,0169,9B520FB6,Group,Void,ai_cannot_die,// B612529E",
                "00021175,B62B52B7,B63752C3,0004,B8522CB6,Group,Void,set,// B63152BD",
                "00021271,B68B5317,B6955321,0169,18538CB6,Group,Void,ai_cannot_die,// B68F531B",
                "00021300,B6A85334,B6B45340,0004,3553A9B6,Group,Void,set,// B6AE533A",
                "00021396,B7085394,B712539E,0169,955309B7,Group,Void,ai_cannot_die,// B70C5398",
                "00021425,B72553B1,B73153BD,0004,B25326B7,Group,Void,set,// B72B53B7",
                "00021517,B781540D,B78B5417,0169,0E5482B7,Group,Void,ai_cannot_die,// B7855411",
                "00021546,B79E542A,B7AA5436,0004,2B549FB7,Group,Void,set,// B7A45430",
                "00021638,B7FA5486,B8045490,0169,8754FBB7,Group,Void,ai_cannot_die,// B7FE548A",
                "00021753,B86D54F9,B8775503,0169,FA546EB8,Group,Void,ai_cannot_die,// B87154FD",
                "00021795,B8975523,FFFFFFFF,0169,245598B8,Group,Void,ai_cannot_die,// B89B5527",
                "00022403,BAF75783,BB03578F,0004,8457F8BA,Group,Void,set,// BAFD5789",
                "00022523,BB6F57FB,BB795805,0169,FC5770BB,Group,Void,ai_cannot_die,// BB7357FF",
                "00022689,BC1558A1,BC1C58A8,017F,A25816BC,Group,Void,ai_allegiance,// BC1958A5",
                "00023456,BF145BA0,FFFFFFFF,01B1,A15B15BF,Group,Void,ai_set_objective,// BF185BA4",
                "00027973,D0B96D45,D0C36D4F,0169,466DBAD0,Group,Void,ai_cannot_die,// D0BD6D49",
                "00028614,D33A6FC6,D3486FD4,0016,C76F3BD3,Group,Void,sleep_until,// D3426FCE",
                "00028649,D35D6FE9,D3676FF3,0169,EA6F5ED3,Group,Void,ai_cannot_die,// D3616FED",
                "00028675,D3777003,D381700D,0192,047078D3,Group,Void,ai_force_active,// D37B7007",
                "00029030,D4DA7166,D4EF717B,0017,6771DBD4,Group,Void,wake,// D4DD7169",
                "00029086,D512719E,D52771B3,0166,9F7113D5,Group,Void,ai_place,// D51571A1",
                "00034658,EAD68762,EAEF877B,0006,6387D7EA,Group,Boolean,or,// EAE98775",
                "00034789,EB5987E5,EABD8749,0000,00000000,Expression,FunctionName,begin,// EABD8749 disable the whole thing for now",
                "00035083,EC7F890B,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// EB5F87EB disable the whole thing for now",
                "00035212,ED00898C,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// EC858911 disable the whole thing for now",
                "00035397,EDB98A45,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// ED068992 disable the whole thing for now",
                "00035767,EF2B8BB7,FFFFFFFF,0000,00000000,Expression,FunctionName,begin,// EF238BAF",
                "00035910,EFBA8C46,EFC08C4C,0333,478CBBEF,Group,Void,switch_zone_set,// EFBD8C49",
            },
        };
    }
}
