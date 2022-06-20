using MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TestTD : MonoBehaviour
{
    public BindingData bindingData;

    private void Awake()
    {
        Button button; //onClick (UnityEvent)
        Slider slider; //onValueChange (UnityEvent<float>)
        Toggle toggle; //onValueChange (UnityEvent<bool>)
        Dropdown dropdown; //onValueChange (UnityEvent<int>)
        ScrollRect scrollRect; //onValueChange (UnityEvent<Vector2>)

        TMP_InputField inputField;
        // inputField.onValueChanged;
        // inputField.onDeselect;
        // inputField.onSelect;
        // inputField.onSubmit;
        // inputField.onEndEdit;
        // inputField.onTextSelection; //UnityEvent<string,int,int>
        // inputField.onEndTextSelection;
        // inputField.onTouchScreenKeyboardStatusChanged;
        
        Scrollbar scrollbar; //scrollbar.onValueChanged
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bindingData.ViewEndpoint.SetValue(Random.Range(1, 999));
        }
    }
}