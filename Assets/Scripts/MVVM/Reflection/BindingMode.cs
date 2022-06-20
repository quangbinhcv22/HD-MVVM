namespace MVVM.Reflection
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
    }
}