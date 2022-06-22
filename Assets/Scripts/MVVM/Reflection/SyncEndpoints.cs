namespace MVVM.Reflection
{
    public class SyncEndpoints
    {
        private readonly PropertyEndpoint _sourceEndpoint;
        private readonly PropertyEndpoint _destEndpoint;

        public SyncEndpoints(PropertyEndpoint sourceEndpoint, PropertyEndpoint destEndpoint)
        {
            _sourceEndpoint = sourceEndpoint;
            _destEndpoint = destEndpoint;
        }

        public void SyncFormSource()
        {
            _destEndpoint.SetValue(_sourceEndpoint.GetValue());
        }

        public void SyncFormDest()
        {
            _sourceEndpoint.SetValue(_destEndpoint.GetValue());
        }
    }
}