using NCB.MVVM;
using NCB.DataView;
using UnityEngine;

public class TestTD : MonoBehaviour
{
    [SerializeField] DataCoreView coreView;
    [SerializeField] PlayerData a;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coreView.Data = a;
        }
    }
}