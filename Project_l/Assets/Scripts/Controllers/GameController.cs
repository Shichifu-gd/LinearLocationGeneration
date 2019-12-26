using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private bool SwichHideCursor = true;

    private void Start()
    {
        HideCursor();
    }

    private void HideCursor()
    {
        if (SwichHideCursor == true) Cursor.visible = false;
    }
}