using System;

namespace NCB.MVVM
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BindingAttribute : Attribute
    {
        public string Name;

        public BindingAttribute(string name)
        {
            Name = name;
        }
    }
}