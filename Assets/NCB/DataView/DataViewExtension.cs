using System;
using System.Linq;
using System.Reflection;
using NCB.MVVM;

namespace NCB.DataView
{
    public static class DataViewExtension
    {
        public static object Get(this object obj, string memberPath)
        {
            if (obj is null) return null;
            return memberPath.Split('.').Aggregate(obj, (current, member) => GetNextMember(current, member));
        }

        private static object GetNextMember(this object obj, string memberName)
        {
            var member = FindMember(memberName);

            return member.MemberType switch
            {
                MemberTypes.Field => ((FieldInfo) member).GetValue(obj),
                MemberTypes.Property => ((PropertyInfo) member).GetValue(obj),
                MemberTypes.Method => ((MethodInfo) member).Invoke(obj, null),
                _ => null,
            };

            MemberInfo FindMember(string name)
            {
                foreach (var member in obj.GetType().GetMembers())
                {
                    foreach (var attribute in member.GetCustomAttributes())
                    {
                        if (attribute is DataViewAttribute dateView)
                        {
                            if (dateView.Name == name) return member;
                        }
                    }
                }

                var queryMembers = obj.GetType().GetMember(memberName);
                return queryMembers.Any()
                    ? queryMembers.First()
                    : throw new UnableAccessDataViewException(
                        $"<color=yellow>{obj.GetType()}</color>: make sure <color=yellow>{memberName}</color> exists or is accessible");
            }
        }


        public static void Set(this object obj, string memberPath, object value)
        {
            if (obj is null) return;

            if (obj.Get(memberPath) == value) return;

            if (memberPath.Contains('.'))
            {
                var tienTo = memberPath.Substring(default, memberPath.LastIndexOf('.'));
                var memberName = memberPath.Substring(memberPath.LastIndexOf('.') + 1,
                    memberPath.Length - memberPath.LastIndexOf('.') - 1);

                var chaMember = obj.Get(tienTo);

                var memberInfo = chaMember.GetType().GetMember(memberName).First();
                memberInfo.SetMemberValue(chaMember, value);
            }
            else
            {
                var memberInfo = obj.GetType().GetMember(memberPath).First();
                memberInfo.SetMemberValue(obj, value);
            }
        }
    }


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.Property)]
    public class DataViewAttribute : Attribute
    {
        public readonly string Name;

        public DataViewAttribute(string name)
        {
            Name = name;
        }
    }

    public class UnableAccessDataViewException : Exception
    {
        public UnableAccessDataViewException(string message) : base(message)
        {
        }
    }
}