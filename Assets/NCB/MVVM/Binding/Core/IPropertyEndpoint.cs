namespace NCB.MVVM
{
    public interface IPropertyEndpoint
    {
        public object GetValue();
        public void SetValue(object value);
    }
}