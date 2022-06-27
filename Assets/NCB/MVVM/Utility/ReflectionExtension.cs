using System;
using System.Linq;
using System.Reflection;

namespace NCB.MVVM
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

        public static void SetMemberValue(this MemberInfo member, object obj, object value)
        {
            switch (member)
            {
                case FieldInfo field:
                {
                    if (field.FieldType != value.GetType())
                    {
                        var castedValue = Convert.ChangeType(value, field.FieldType);
                        field.SetValue(obj, castedValue);
                    }
                    else
                    {
                        field.SetValue(obj, value);
                    }

                    break;
                }
                case PropertyInfo property:
                {
                    var setMethod = property?.GetSetMethod(true);
                    if (setMethod == null) throw new ArgumentException("Property " + member.Name + " has no setter");

                    if (value != null && property.PropertyType != value.GetType() && value is IConvertible)
                    {
                        var castedValue = Convert.ChangeType(value, property.PropertyType);
                        property.SetValue(obj, castedValue);
                    }
                    else
                    {
                        property.SetValue(obj, value);
                    }

                    break;
                }

                case MethodInfo method:
                {
                    var parameters = method.GetParameters();

                    if (value != null && parameters.Any())
                    {
                        var firstParameter = parameters.First();

                        if (firstParameter.ParameterType != value.GetType())
                        {
                            var castedValue = Convert.ChangeType(value, firstParameter.ParameterType);
                            method.Invoke(obj, new[] {castedValue});
                        }
                        else
                        {
                            method.Invoke(obj, new[] {value});
                        }
                    }
                    else
                    {
                        method.Invoke(obj, null);
                    }

                    break;
                }
                default:
                    throw new ArgumentException("Can't set the value of a " + member.GetType().Name);
            }
        }

        public static object GetMemberValue(this MemberInfo member, object obj)
        {
            return member switch
            {
                FieldInfo filed => filed.GetValue(obj),
                PropertyInfo property => property.GetGetMethod(true).Invoke(obj, null),
                MethodInfo method => method?.Invoke(obj, null),
                _ => throw new ArgumentException("Can't get the value of a " + member.GetType().Name)
            };
        }


        public static bool IsPropertyOrField(this MemberInfo memberInfo)
        {
            return (MemberTypes.Property | MemberTypes.Field).HasFlag(memberInfo.MemberType);
        }


        public static bool IsObsolete(object owner, string memberName)
        {
            return owner.GetType().GetMember(memberName).First().IsObsolete();
        }

        public static bool NotObsolete(object owner, string memberName)
        {
            return !IsObsolete(owner, memberName);
        }

        public static bool IsObsolete(this MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttribute<ObsoleteAttribute>() != null;
        }

        public static bool NotObsolete(this MemberInfo memberInfo)
        {
            return !memberInfo.IsObsolete();
        }

        public static bool IsObsolete(this Type type)
        {
            if (type is null) return false;
            return type.GetCustomAttribute<ObsoleteAttribute>() != null;
        }

        public static bool NotObsolete(this Type type)
        {
            return !type.IsObsolete();
        }


        public static bool MatchRequire(this MemberInfo memberInfo, PropertyAccess access)
        {
            if (memberInfo is FieldInfo) return true;
            if (memberInfo is PropertyInfo property)
            {
                var requireGet = access.HasFlag(PropertyAccess.Get);
                var requireSet = access.HasFlag(PropertyAccess.Set);

                var canGet = property.GetGetMethod() != null;
                var canSet = property.GetSetMethod() != null;

                var passGet = !requireGet || canGet;
                var passSet = !requireSet || canSet;

                return passGet && passSet;
            }


            return false;
        }

        public static bool CanGet(this MemberInfo memberInfo)
        {
            if (memberInfo is FieldInfo) return true;
            if (memberInfo is PropertyInfo property) return property.GetGetMethod() != null;
            return false;
        }

        public static bool CanSet(this MemberInfo memberInfo)
        {
            if (memberInfo is FieldInfo) return true;
            if (memberInfo is PropertyInfo property) return property.GetSetMethod() != null;
            return false;
        }
    }
}