namespace MVVM.Reflection
{
    public class SyncEndpoints
    {
        private readonly MemberEndpoint _sourceEndpoint;
        private readonly MemberEndpoint _destEndpoint;

        public SyncEndpoints(MemberEndpoint sourceEndpoint, MemberEndpoint destEndpoint)
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