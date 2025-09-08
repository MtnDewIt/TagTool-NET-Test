using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TagTool.Tags;

namespace TagTool.Common
{
    public static class ReflectionHelpers
    {
		//cache for delegate for AddRangeBoxed on TagBlock<T>
		public delegate void AddRangeBoxedDelegate(object instance, ReadOnlySpan<object> boxedValues);
		private static readonly Dictionary<Type, AddRangeBoxedDelegate> addRangeBoxedDelegatedLookup = new();
		private static readonly Type[] Types_Object_ROSObject = new Type[] { typeof(object), typeof(ReadOnlySpan<object>) };
		public static AddRangeBoxedDelegate GetAddRangeBoxedDelegate(Type t)
		{
			Debug.Assert(t.GetGenericTypeDefinition() == typeof(TagBlock<>));
			if (addRangeBoxedDelegatedLookup.TryGetValue(t, out var value)) return value;
			else return Fallback(t);
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			static AddRangeBoxedDelegate Fallback(Type t)
			{
				DynamicMethod m = new("AddRangeBoxedDelegateImpl+" + t.FullName, typeof(void), Types_Object_ROSObject);
				var ilGen = m.GetILGenerator();
				ilGen.Emit(OpCodes.Ldarg_0);
#if DEBUG
				ilGen.Emit(OpCodes.Castclass, t);
#endif
				ilGen.Emit(OpCodes.Ldarg_1);
				ilGen.EmitCall(OpCodes.Callvirt, t.GetMethod("AddRangeBoxed"), null);
				ilGen.Emit(OpCodes.Ret);
				var result = m.CreateDelegate<AddRangeBoxedDelegate>();
				addRangeBoxedDelegatedLookup[t] = result;
				return result;
			}
		}

        public static T GetFirstInstanceOfType<T>(object obj, HashSet<object> visited = null) where T : class
        {
            if (obj == null)
                return null;

            if (obj is T match)
                return match;

            visited ??= new HashSet<object>();

            if (visited.Contains(obj))
                return null;

            var type = obj.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var value = field.GetValue(obj);

                if (value is T found)
                    return found;

                if (value != null && value is not string && !(value.GetType().IsValueType))
                {
                    var result = GetFirstInstanceOfType<T>(value, visited);

                    if (result != null)
                        return result;
                }
            }

            return null;
        }
    }
}
