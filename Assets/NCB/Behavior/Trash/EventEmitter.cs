using System;
using System.Collections;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class EventEmitter : MonoBehaviour
{
    [SerializeField] [ValueDropdown("@EventNameProvider.EventNames")] [LabelText("Event Name")]
    private string eventPath;

    [SerializeField] private Object data;

    public void Emit()
    {
        if (data)
        {
            Debug.Log($"Emit event: {eventPath}, Data: {data}");
        }
        else
        {
            Debug.Log($"Emit event: {eventPath}");
        }
    }
}

public static class EventNameProvider
{
    public static IEnumerable EventNames
    {
        get
        {
            ValueDropdownList<string> values = new();

            var categories = typeof(EventName).GetNestedTypes();

            foreach (var category in categories)
            {
                values.AddRange(category.GetFields().Select(field => new ValueDropdownItem<string>(
                    $"{category.Name}/{field.Name}", $"{nameof(EventName)}.{category.Name}.{field.Name}")).ToList());
            }

            return values;
        }
    }
}

public static class EventName
{
    public static class Server
    {
        public const string Connect = "ServerConnect";
        public const string Disconnect = "ServerDisconnect";
    }

    public static class UI
    {
        public const string OnLogin = "UIOnLogin";
        public const string Exit = "UIExit";
    }

    public static class Audio
    {
        public const string PlaySound = "AudioPlaySound";
    }
}

public class ThreadCallbackEvent : MonoBehaviour
{
    [SerializeField] private string eventName;
}