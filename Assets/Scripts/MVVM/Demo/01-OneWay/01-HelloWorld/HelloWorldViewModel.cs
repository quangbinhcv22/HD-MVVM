using MVVM.ModelView;
using UnityEngine;

namespace MVVM.Demo
{
    [Binding]
    public class HelloWorldViewModel : MonoBehaviour
    {
        public string HelloText => "Hello World!";
    }
}