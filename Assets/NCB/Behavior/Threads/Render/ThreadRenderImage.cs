using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadRenderImage : ThreadBehavior
    {
        private void OnRenderImage(RenderTexture src, RenderTexture dest) => Run();
    }
}