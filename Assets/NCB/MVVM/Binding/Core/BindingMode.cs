namespace NCB.MVVM
{
    public enum BindingMode
    {
        OneWay = 0,
        TwoWay = 1,
        OneWayToSource = 2,
    }
    
    public static class BindingModeExtension
    {
        public static bool HaveSyncFromSource(this BindingMode mode)
        {
            return mode is BindingMode.OneWay or BindingMode.TwoWay;
        }

        public static bool HaveSyncFromDest(this BindingMode mode)
        {
            return mode is BindingMode.TwoWay or BindingMode.OneWayToSource;
        }

        public static PropertyAccess GetSourceRequireAccess(this BindingMode mode)
        {
            return mode switch
            {
                BindingMode.OneWay => PropertyAccess.Get,
                BindingMode.TwoWay => PropertyAccess.All,
                BindingMode.OneWayToSource => PropertyAccess.Set,
                _ => PropertyAccess.Unset,
            };
        }
        
        public static PropertyAccess GetDestRequireAccess(this BindingMode mode)
        {
            return mode switch
            {
                BindingMode.OneWay => PropertyAccess.Set,
                BindingMode.TwoWay => PropertyAccess.All,
                BindingMode.OneWayToSource => PropertyAccess.Get,
                _ => PropertyAccess.Unset,
            };
        }
    }
}