using MVVM.ViewBuilder;
using TMPro;
using UnityEngine;

public class TestTD : MonoBehaviour
{
    // [SerializeField] DataCoreView coreView;
    [SerializeField] ClassA a;

    private void Awake()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // coreView.Data = a;
        }
    }
}