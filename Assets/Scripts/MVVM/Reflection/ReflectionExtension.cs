using System;
using System.Reflection;

namespace MVVM.Reflection
{
    public static class ReflectionExtension
    {
        public static Type ReturnType(this MemberInfo member)
        {
            return member switch
            {
                FieldInfo field => field.FieldType,
                PropertyInfo property => property.PropertyType,
                MethodInfo method => method.ReturnType,
                _ => throw new ArgumentException("Can't get return typr of a " + member.GetType().Name)
            };
        }

        public static void SetValue(this MemberInfo member, object obj, object value)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    (member as FieldInfo)?.SetValue(obj, value);
                    break;
                case MemberTypes.Property:
                    MethodInfo setMethod = (member as PropertyInfo)?.GetSetMethod(true);
                    if (setMethod == null) throw new ArgumentException("Property " + member.Name + " has no setter");
                    setMethod.SetValue(obj, value);
                    break;
                case MemberTypes.Method:
                    (member as MethodInfo)?.Invoke(obj, new[] {value});
                    break;
                default:
                    throw new ArgumentException("Can't set the value of a " + member.GetType().Name);
            }
        }

        public static object GetValue(this MemberInfo member, object obj)
        {
            return member switch
            {
                FieldInfo filed => filed.GetValue(obj),
                PropertyInfo property => property.GetGetMethod(true).Invoke(obj, null),
                MethodInfo method => method?.Invoke(obj, null),
                _ => throw new ArgumentException("Can't get the value of a " + member.GetType().Name)
            };
        }
    }
}