using MVVM.ModelView;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM.Demo
{
    [Binding]
    public class FpsViewModel : MonoBehaviour
    {
        [ShowInInspector] public float Fps { get; set; }

        private void Update()
        {
            Fps = Time.frameCount / Time.time;
        }
    }
}
