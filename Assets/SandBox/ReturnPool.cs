using UnityEngine;

public class ReturnPool : MonoBehaviour
{
    public void Return()
    {
        Instantiate(gameObject,Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }
}