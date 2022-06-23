using MVVM.ViewBuiler;

namespace MVVM.Reflection
{
    public class SyncEndpoints
    {
        private readonly IPropertyEndpoint _sourceEndpoint;
        private readonly IPropertyEndpoint _destEndpoint;

        public SyncEndpoints(IPropertyEndpoint sourceEndpoint, IPropertyEndpoint destEndpoint)
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