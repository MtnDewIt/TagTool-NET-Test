using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
		private static readonly ConditionalWeakTable<Type, AddRangeBoxedDelegate> addRangeBoxedDelegatedLookup = new();
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
				ilGen.EmitCall(OpCodes.Callvirt, t.GetMethod("AddRangeBoxedDelegate"), null);
				ilGen.Emit(OpCodes.Ret);
				var result = m.CreateDelegate<AddRangeBoxedDelegate>();
				addRangeBoxedDelegatedLookup.AddOrUpdate(t, result);
				return result;
			}
		}
	}
}
