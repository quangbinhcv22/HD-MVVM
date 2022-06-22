using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MVVM.Demo;
using MVVM.Reflection;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace MVVM.ViewBuilder
{
    public class DataMemberView : MonoBehaviour
    {
        [SerializeField] private BindingMode mode;

        [SerializeField] private DataCoreProperty source;
        [SerializeField] private ComponentEndpoint dest;

        [SerializeField] [ShowIf(nameof(HaveSyncFromDest))]
        private ComponentEvent destEvent;

        [SerializeField] [Space] private bool bindingOnEnable = true;
        [SerializeField] private bool keepBindingOnDisable;


        private bool HaveSyncFromSource => mode.HaveSyncFromSource();
        private bool HaveSyncFromDest => mode.HaveSyncFromDest();


        private SyncEndpoints _syncEndpoints;
        private readonly List<EventWatcher> _eventWatchers = new List<EventWatcher>();


        private void Awake()
        {
            _syncEndpoints = new SyncEndpoints(source.ToEndpoint(), dest.ToEndpoint());

            if (HaveSyncFromSource) _eventWatchers.Add(source.ToWatcher(_syncEndpoints.SyncFormSource));
            if (HaveSyncFromDest) _eventWatchers.Add(destEvent.ToWatcher(_syncEndpoints.SyncFormDest));
        }

        private void OnEnable()
        {
            if (bindingOnEnable && mode.HaveSyncFromSource()) _syncEndpoints.SyncFormSource();
            _eventWatchers.ForEach(watcher => watcher.Watch());
        }

        private void OnDisable()
        {
            if (keepBindingOnDisable) return;
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }

        private void OnDestroy()
        {
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }

        public void OnValidate()
        {
            if (source != null) source.isShowAdapter = HaveSyncFromDest;
            if (dest != null) dest.isShowAdapter = HaveSyncFromSource;
        }
    }

    [Serializable]
    public class DataCoreProperty
    {
        [SerializeField] [BoxGroup] private DataCoreView coreView;

        [SerializeField] [BoxGroup] private string memberName;

        [SerializeField] [BoxGroup] [ShowIf(nameof(isShowAdapter))]
        private DataAdapter.DataAdapter dataAdapter;


        public PropertyEndpoint ToEndpoint()
        {
            // return new MemberEndpoint(coreView.Data, memberName, dataAdapter);
            return new PropertyEndpoint(coreView, "Data", dataAdapter);
        }

        public EventWatcher ToWatcher(Action callback)
        {
            Debug.Log("ToWatcher");

            return new PropertyChangedWatcher(coreView, "Data", callback);
        }


#if UNITY_EDITOR
        [HideInInspector] public bool isShowAdapter = true;
#endif

        private IEnumerable GetMembers()
        {
            if (coreView is null) return new List<string>();

            const MemberTypes allowTypes = MemberTypes.Field | MemberTypes.Property | MemberTypes.Method;
            return coreView.DataType.GetMembers().Where(m => allowTypes.HasFlag(m.MemberType))
                .Select(property => property.Name).ToList();
        }

        //Fail, de dung may o editor
        // public static IEnumerable GetMembersByType(Type type)
        // {
        //     const MemberTypes allowTypes = MemberTypes.Field | MemberTypes.Property;
        //
        //     var values = new ValueDropdownList<string>();
        //
        //
        //     var currentMemberRoot = new List<TypeMember>();
        //
        //     foreach (var member in type.GetMembers())
        //     {
        //         if (!allowTypes.HasFlag(member.MemberType)) continue;
        //
        //         currentMemberRoot.Add(new TypeMember(member, member.Name));
        //         values.Add(member.Name, member.Name);
        //     }
        //
        //     while (currentMemberRoot.Any())
        //     {
        //         var nextMemberRoot = new List<TypeMember>();
        //
        //         foreach (var root in currentMemberRoot)
        //         {
        //             var aRoot = root.Key.ReturnType().GetMembers();
        //             if (aRoot.Any(member => member.Name == root.Key.Name)) continue;
        //
        //             foreach (var member in aRoot)
        //             {
        //                 if (nextMemberRoot.Count >= 15) return values;
        //                 
        //                 if (!allowTypes.HasFlag(member.MemberType) || member.Name == root.Key.Name || member.IsStatic()) continue;
        //
        //                 var memberName = root.Value + "." + member.Name;
        //
        //                 nextMemberRoot.Add(new TypeMember(member, memberName));
        //                 values.Add(memberName.Replace(".", "/"), memberName);
        //             }
        //         }
        //
        //         currentMemberRoot = nextMemberRoot;
        //     }
        //
        //
        //     foreach (var value in values)
        //     {
        //         Debug.Log(value.Text);
        //     }
        //     
        //     return values;
        // }
        //
        // public class TypeMember
        // {
        //     public MemberInfo Key;
        //     public string Value;
        //
        //     public TypeMember(MemberInfo key, string value)
        //     {
        //         Key = key;
        //         Value = value;
        //     }
        // }
    }
}