using NCB.Behavior;
using UnityEngine;

public sealed class ThreadDelay : ThreadBehavior
{
    [SerializeField] [Space] private float delay;

    private void Awake()
    {
        RunWithDelay();
    }

    public void RunWithDelay()
    {
        Invoke(nameof(Run), delay);
    }
}