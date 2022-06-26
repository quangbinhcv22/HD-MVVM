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
    }
}