using UnityEngine;

namespace NCB.MVVM.Demo
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private new Renderer renderer;

        public Color color
        {
            set => SetColor(value);
        }

        private void SetColor(Color color)
        {
            renderer.material.color = color;
        }
    }
}