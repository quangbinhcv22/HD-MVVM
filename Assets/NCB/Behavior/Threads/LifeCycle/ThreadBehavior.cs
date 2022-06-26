using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.Behavior
{
    [HideMonoScript]
    public class ThreadBehavior : MonoBehaviour
    {
        [SerializeField]
        [HideLabel]
        [Space]
        [PropertyOrder(100)]
        private BehaviorThread behaviorThread;

        public void Run() => behaviorThread.Run();
    }
}