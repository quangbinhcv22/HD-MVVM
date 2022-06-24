using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{
    public static void Active(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public static void DeActive(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}