using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "MVVM/TypeDifine", fileName = nameof(TypeDefine))]
public class TypeDefine : ScriptableObject
{
    [SerializeField] private string assembly;
    [SerializeField] private string type;

    public new Type GetType()
    {
        var queryAssembly = AppDomain.CurrentDomain.GetAssemblies().First(ass => ass.FullName == assembly);
        return queryAssembly.GetType(type);
    }

    private void OnValidate()
    {
        Debug.Log(Assembly.GetAssembly(typeof(GameObject)));
    }
}