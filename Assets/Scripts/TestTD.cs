using MVVM.ViewBuilder;
using UnityEngine;

public class TestTD : MonoBehaviour
{
    [SerializeField] DataCoreView coreView;
    [SerializeField] ClassA a;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coreView.Data = a;
        }
    }
}