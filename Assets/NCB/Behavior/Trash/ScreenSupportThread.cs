using System;
using System.Collections.Generic;
using NCB.Behavior;
using Sirenix.OdinInspector;
using UnityEngine;

public class ScreenSupportThread : MonoBehaviour
{
    [SerializeField] private List<ScreenStageThread> lifecycle;
}

public enum ScreenStage
{
    Unset = 0,
    Initialize = 1,
    WillPushEnter = 2,
    DidPushEnter = 3,
    WillPushExit = 4,
    DidPushExit = 5,
    WillPopEnter = 6,
    DidPopEnter = 7,
    WillPopExit = 8,
    DidPopExit = 9,
}


[Serializable]
public class ScreenStageThread
{
    [BoxGroup] public ScreenStage stage;
    [HideLabel] [Space] public BehaviorThread thread;
}