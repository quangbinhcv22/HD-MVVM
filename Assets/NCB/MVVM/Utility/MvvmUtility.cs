using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEditor;

namespace NCB.MVVM
{
    public static class MvvmUtility
    {
        public static List<ValueDropdownItem<string>> GetAllModelViewsName()
        {
            return GetAllModelViews().OrderBy(member => member.FullName).Select(member => new ValueDropdownItem<string>(member.FullName.Replace('.', '/'), member.FullName)).ToList();
        }

        private static IEnumerable<Type> GetAllModelViews()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsDefined(typeof(BindingAttribute)));
        }

        public static List<string> GetAllModelViewProperties(string viewModelName)
        {
            if (string.IsNullOrEmpty(viewModelName)) return new List<string>();

            var modelViewType = Type.GetType(viewModelName);
            if (modelViewType is null) return new List<string>();

            var bindingProperty = modelViewType.GetMembers().Where(member =>
                member.MemberType is MemberTypes.Property);

            return bindingProperty.Select(member => member.Name).OrderBy(name => name).ToList();
        }

        public static List<string> GetAllModelViewMethods(string viewModelName)
        {
            if (string.IsNullOrEmpty(viewModelName)) return new List<string>();

            var modelViewType = Type.GetType(viewModelName);
            if (modelViewType is null) return new List<string>();

            var methods = modelViewType.GetMethods().Where(m => m.ReturnType == typeof(void))
                .Where(m => m.GetParameters().Length == 0);

            return methods.Select(member => member.Name).Where(n =>
                    !(n.Contains("get_") || n.Contains("set_") || n.Contains("add_") || n.Contains("remove_")))
                .ToList();
        }

#if UNITY_EDITOR
        public static void OpenViewModelAsset(string viewModelType)
        {
            var str = AssetDatabase.FindAssets(viewModelType.Split('.').Last()).FirstOrDefault();
            var path = AssetDatabase.GUIDToAssetPath(str);
            var asset = EditorGUIUtility.Load(path);
            AssetDatabase.OpenAsset(asset);
        }
#endif
    }
}