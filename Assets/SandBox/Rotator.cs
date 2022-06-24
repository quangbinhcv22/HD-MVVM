using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 velocity;

    private bool _rotating;
    
    public void StartRotate()
    {
        _rotating = true;
    }

    public void StopRotate()
    {
        _rotating = false;
    }

    private void Update()
    {
        if(_rotating) target.Rotate(velocity);
    }
}
