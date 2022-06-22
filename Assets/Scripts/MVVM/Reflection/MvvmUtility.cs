using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MVVM.ModelView;
using UnityEditor;

namespace MVVM.Reflection
{
    public static class MvvmUtility
    {
        public static List<string> GetAllModelViewsName()
        {
            return GetAllModelViews().Select(member => member.FullName).OrderBy(name => name).ToList();
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

            var bindingProperty = modelViewType.GetMembers().Where(member =>
                member.MemberType is MemberTypes.Method);

            return bindingProperty.Select(member => member.Name).ToList();
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