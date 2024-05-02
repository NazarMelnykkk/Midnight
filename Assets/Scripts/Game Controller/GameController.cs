using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        CursorVisible(false);
    }

    public void CursorVisible(bool value)
    {
        Cursor.visible = value;
    }
}
