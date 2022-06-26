namespace NCB.Behavior
{
    public sealed class ThreadApplicationNotFocus : ThreadBehavior
    {
        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus) Run();
        }
    }
}