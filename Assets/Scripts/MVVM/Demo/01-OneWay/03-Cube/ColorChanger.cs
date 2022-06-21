using UnityEngine;

namespace MVVM.Demo
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private new Renderer renderer;

        public void SetColor(Color color)
        {
            renderer.material.color = color;
        }
    }
}