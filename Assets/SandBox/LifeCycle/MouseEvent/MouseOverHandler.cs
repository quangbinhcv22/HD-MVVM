namespace Game.Runtime
{
    public sealed class MouseOverHandler : ComponentEventHandler
    {
        private void OnMouseExit() => InvokeEvent();
    }
}