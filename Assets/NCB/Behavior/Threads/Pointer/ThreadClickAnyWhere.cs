using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadClickAnyWhere : ThreadBehavior
    {
        private void Update()
        {
            if(Input.GetMouseButtonDown(default)) Run();
        }
    }
}