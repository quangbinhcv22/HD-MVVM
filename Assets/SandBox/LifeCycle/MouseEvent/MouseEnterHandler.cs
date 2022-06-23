namespace Game.Runtime
{
    public sealed class MouseEnterHandler : ComponentEventHandler
    {
        private void OnMouseEnter() => InvokeEvent();
    }
}