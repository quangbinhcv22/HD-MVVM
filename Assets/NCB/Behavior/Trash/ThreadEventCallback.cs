using NCB.Behavior;
using Sirenix.OdinInspector;
using UnityEngine;

public class ThreadEventCallback : ThreadBehavior
{
    [SerializeField] [ValueDropdown("@EventNameProvider.EventNames")] [LabelText("Event Name")] [Space]
    private string eventPath;


    private void Awake()
    {
    }

    private void OnCallback()
    {
        Run();
    }
}