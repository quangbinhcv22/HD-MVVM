using MVVM.ModelView;
using UnityEngine;

namespace MVVM.Demo
{
    [Binding]
    public class CubeViewModel
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Color Color => Color.green;
    }
}