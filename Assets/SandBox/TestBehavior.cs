using NCB.Behavior;
using UnityEngine;

public class TestBehavior : MonoBehaviour
{
    [SerializeField] private BehaviorThread behaviorThread;

    private void Start()
    {
        behaviorThread.Run();
    }
}
