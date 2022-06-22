using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogList : MonoBehaviour
{
    public IEnumerable _collection;
    public IEnumerable Collection
    {
        get => _collection;
        set
        {
            _collection = value;
            Log();
        }
    }

    private void Log()
    {
        Debug.Log("Start log");
        
        foreach (var item in _collection)
        {
            Debug.Log(item);
        }
    }
}
