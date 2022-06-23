﻿using System.Collections.Generic;
using System.Reflection;
using MVVM.ViewBuilder;

namespace MVVM.ViewBuiler
{
    public class MemberPathEndpoint : IPropertyEndpoint
    {
        private object _owner;
        private string _memberPath;

        private List<MemberInfo> _members;

        public MemberPathEndpoint(object owner, string memberPath)
        {
            SetOwner(owner);
            SetPath(memberPath);
        }

        public void SetOwner(object owner)
        {
            _owner = owner;
            SetPath(_memberPath);
        }

        public void SetPath(string path)
        {
            _memberPath = path;

            if (string.IsNullOrEmpty(_memberPath) || _owner.Equals(null)) return;

            // _memberInfo = _owner.GetType().GetMember(_memberName).FirstOrDefault();
        }

        public object GetValue()
        {
            return _owner.Get(_memberPath);
        }

        public void SetValue(object value)
        {
            
        }
    }

    public interface IPropertyEndpoint
    {
        public object GetValue();
        public void SetValue(object value);
    }
}