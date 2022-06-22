using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class TypeDefine
{
    [SerializeField] [ValueDropdown(nameof(AllAssemblies))] [BoxGroup]
    private string assemblyName;

    [SerializeField] [EnableIf(nameof(HaveAssembly))] [ValueDropdown(nameof(AllTypes))] [BoxGroup]
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

    private IEnumerable AllTypes()
    {
        return AppDomain.CurrentDomain.GetAssemblies().First(ass => ass.GetName().Name == assemblyName).GetTypes()
            .OrderBy(member => member.FullName).Select(member =>
                new ValueDropdownItem<string>(member.FullName.Replace('.', '/'), member.FullName)).ToList();
    }

    private bool HaveAssembly()
    {
        return !string.IsNullOrEmpty(assemblyName);
    }
}