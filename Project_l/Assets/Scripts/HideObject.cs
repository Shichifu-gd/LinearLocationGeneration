using UnityEngine;

public class HideObject : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}