using System;
using System.Linq;
using System.Reflection;

namespace MVVM.Reflection
{
    public class MemberEndpoint
    {
        private object _owner;
        private string _memberName;
        private readonly DataAdapter.DataAdapter _dataAdapter;

        private MemberInfo _memberInfo;


        public MemberEndpoint(object owner, string memberName, DataAdapter.DataAdapter dataAdapter)
        {
            SetOwner(owner);
            SetMember(memberName);
            _dataAdapter = dataAdapter;
        }


        public void SetOwner(object owner)
        {
            _owner = owner;
            SetMember(_memberName);
        }

        public void SetMember(string name)
        {
            _memberName = name;
            if (string.IsNullOrEmpty(name) || _owner.Equals(null)) return;
            _memberInfo = _owner.GetType().GetMember(_memberName).FirstOrDefault();
        }


        public object GetValue()
        {
            return _memberInfo.GetValue(_owner);
        }

        public void SetValue(object value)
        {
            if (_dataAdapter)
            {
                var adaptedValue = _dataAdapter.Adapting(value);
                var castedValue = Convert.ChangeType(adaptedValue, _memberInfo.ReturnType());

                _memberInfo.SetValue(_owner, castedValue);
            }
            else
            {
                var castedValue = Convert.ChangeType(value, _memberInfo.ReturnType());
                _memberInfo.SetValue(_owner, castedValue);
            }
        }


        public override string ToString()
        {
            return $"{_owner} ({_memberInfo.Name}): {GetValue()}";
        }
    }
}