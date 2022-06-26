namespace NCB.Behavior
{
    public sealed class ThreadApplicationFocus : ThreadBehavior
    {
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus) Run();
        }
    }
}