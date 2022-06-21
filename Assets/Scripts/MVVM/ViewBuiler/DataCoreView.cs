using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace MVVM.ViewBuilder
{
    // public class DataCoreView : MonoBehaviour
    // {
    //     [SerializeField] private TypeDefine typeDefine;
    //
    //     public Type DataType
    //     {
    //         get
    //         {
    //             if (typeDefine is null)
    //             {
    //                 Debug.Log($"typeDefine is null", this);
    //                 return null;
    //             }
    //
    //             return typeDefine.GetType();
    //         }
    //     }
    //
    //
    //     private object _data;
    //
    //     [ShowPropertyResolver] public object Data
    //     {
    //         get => _data;
    //         set
    //         {
    //             _data = value;
    //             onValueChange?.Invoke();
    //         }
    //     }
    //
    //     public UnityEvent onValueChange;
    // }
}