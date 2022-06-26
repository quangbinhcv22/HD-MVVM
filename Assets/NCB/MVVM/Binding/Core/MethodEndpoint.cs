using System.Reflection;

namespace NCB.MVVM
{
    public class MethodEndpoint
    {
        private object _owner;
        private string _methodName;

        private MethodInfo _methodInfo;

        public MethodEndpoint(object owner, string methodName)
        {
            SetOwner(owner);
            SetMember(methodName);
        }

        public void SetOwner(object owner)
        {
            _owner = owner;
            SetMember(_methodName);
        }

        public void SetMember(string name)
        {
            _methodName = name;

            if (string.IsNullOrEmpty(_methodName) || _owner.Equals(null)) return;

            _methodInfo = _owner.GetType().GetMethod(_methodName);
        }

        public void Invoke()
        {
            _methodInfo?.Invoke(_owner, null);
        }
    }
}