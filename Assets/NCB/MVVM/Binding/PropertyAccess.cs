using System;

namespace NCB.MVVM
{
    [Flags]
    public enum PropertyAccess
    {
        Unset = 0,
        Get = 1,
        Set = 2,
        All = Get | Set,
    }
}