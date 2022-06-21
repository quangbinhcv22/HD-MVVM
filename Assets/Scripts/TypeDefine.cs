using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "MVVM/TypeDefine", fileName = nameof(TypeDefine))]
public class TypeDefine : ScriptableObject
{
    [SerializeField] [ValueDropdown(nameof(AllAssemblies))]
    private string assemblyName;

    [SerializeField] [EnableIf(nameof(HaveAssembly))] [ValueDropdown(nameof(AllTypes))]
    private string typeName;

    [NonSerialized] private Assembly assembly;

    public Assembly GetAssembly()
    {
        return assembly ??= AppDomain.CurrentDomain.GetAssemblies().First(ass => ass.GetName().Name == assemblyName);
    }


    [NonSerialized] private Type type;

    public new Type GetType()
    {
        return type ??= GetAssembly().GetType(typeName);
    }


    private List<string> AllAssemblies()
    {
        return AppDomain.CurrentDomain.GetAssemblies().Select(ass => ass.GetName().Name).OrderBy(name => name).ToList();
    }

    private List<string> AllTypes()
    {
        return AppDomain.CurrentDomain.GetAssemblies().First(ass => ass.GetName().Name == assemblyName).GetTypes()
            .Select(t => t.ToString()).OrderBy(name => name).ToList();
    }

    private bool HaveAssembly()
    {
        return !string.IsNullOrEmpty(assemblyName);
    }
}