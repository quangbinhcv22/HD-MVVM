using System;
using MVVM.Reflection;
using TMPro;
using UnityEngine;

public class TestEndPoint : MonoBehaviour
{
    public float sourceNumber;
    public ClassA destNumber;

    private MemberEndpoint _sourceEndpoint;
    private MemberEndpoint _destEndpoint;

    private SyncEndpoints _syncEndpoints;

    private void Start()
    {
        // _sourceEndpoint = new MemberEndpoint(this, nameof(sourceNumber));
        // _destEndpoint = new MemberEndpoint(destNumber, "GetNumber");

        _syncEndpoints = new SyncEndpoints(_sourceEndpoint, _destEndpoint);
    }

    private void Update()
    {
        // TMP_Text a; a.SetText();
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _syncEndpoints.SyncFormSource();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _syncEndpoints.SyncFormDest();
        }
    }
}

[Serializable]
public class ClassA
{
    [SerializeField] private float number;

    public float Number
    {
        get => number;
        set => number = value;
    }
}