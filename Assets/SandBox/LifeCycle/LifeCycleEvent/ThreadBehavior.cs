using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Runtime
{
    [HideMonoScript]
    public class ThreadBehavior : MonoBehaviour
    {
        [SerializeField] [HideLabel] [Space] [DisableInPlayMode]
        private BehaviorThread behaviorThread;
        public void Run() => behaviorThread.Run();
    }
}