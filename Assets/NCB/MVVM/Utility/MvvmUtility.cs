using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEditor;

namespace NCB.MVVM
{
    public static class MvvmUtility
    {
        private static readonly Dictionary<string, Type> ViewModelFactory = new();

        static MvvmUtility()
        {
            var allViewModels = MvvmUtility.GetAllModelViews();

            foreach (var viewModel in allViewModels)
            {
                if (viewModel.GetCustomAttribute<BindingAttribute>().Name == "unknown") continue;
                ViewModelFactory.Add(viewModel.GetCustomAttribute<BindingAttribute>().Name, viewModel);
            }
        }

        public static List<ValueDropdownItem<string>> GetAllModelViewsName()
        {
            return GetAllModelViews().OrderBy(member => member.FullName).Select(member =>
                new ValueDropdownItem<string>(member.GetCustomAttribute<BindingAttribute>().Name,
                    member.GetCustomAttribute<BindingAttribute>().Name)).ToList();
        }

        public static IEnumerable<Type> GetAllModelViews()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsDefined(typeof(BindingAttribute)));
        }

        public static Type GetViewModelType(string viewModelName)
        {
            try
            {
                return ViewModelFactory[viewModelName];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public static List<string> GetAllModelViewProperties(string viewModelName)
        {
            if (string.IsNullOrEmpty(viewModelName)) return new List<string>();

            var modelViewType = GetViewModelType(viewModelName);
            if (modelViewType is null) return new List<string>();

            var bindingProperty = modelViewType.GetMembers().Where(member => member.IsPropertyOrField())
                .Where(member => member.NotObsolete());

            return bindingProperty.Select(member => member.Name).OrderBy(name => name).ToList();
        }

        public static List<string> GetAllModelViewMethods(string viewModelName)
        {
            if (string.IsNullOrEmpty(viewModelName)) return new List<string>();

            var modelViewType = GetViewModelType(viewModelName);
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
            var str = AssetDatabase.FindAssets(GetViewModelType(viewModelType).Name).FirstOrDefault();
            var path = AssetDatabase.GUIDToAssetPath(str);
            var asset = EditorGUIUtility.Load(path);
            AssetDatabase.OpenAsset(asset);
        }
#endif
    }
}