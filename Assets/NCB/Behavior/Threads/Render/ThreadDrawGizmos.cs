namespace NCB.Behavior
{
    public sealed class ThreadDrawGizmos : ThreadBehavior
    {
        private void OnDrawGizmos() => Run();
    }
}