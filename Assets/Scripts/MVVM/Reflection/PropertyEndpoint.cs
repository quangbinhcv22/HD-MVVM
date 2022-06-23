using System.Linq;
using System.Reflection;
using MVVM.ViewBuiler;

namespace MVVM.Reflection
{
    public class PropertyEndpoint : IPropertyEndpoint
    {
        private object _owner;
        private string _memberName;
        private readonly DataAdapter.DataAdapter _dataAdapter;

        private MemberInfo _memberInfo;


        public PropertyEndpoint(object owner, string memberName, DataAdapter.DataAdapter dataAdapter = null)
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

            if (string.IsNullOrEmpty(_memberName) || _owner.Equals(null)) return;

            _memberInfo = _owner.GetType().GetMember(_memberName).FirstOrDefault();
        }


        public object GetValue()
        {
            return _memberInfo.GetMemberValue(_owner);
        }

        public void SetValue(object value)
        {
            if (_dataAdapter)
            {
                var adaptedValue = _dataAdapter.Adapting(value);
                _memberInfo.SetMemberValue(_owner, adaptedValue);
            }
            else
            {
                _memberInfo.SetMemberValue(_owner, value);
            }
        }


        public override string ToString()
        {
            return $"{_owner} ({_memberInfo.Name}): {GetValue()}";
        }
    }
}