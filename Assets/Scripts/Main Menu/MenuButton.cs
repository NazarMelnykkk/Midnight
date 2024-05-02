using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    protected Button button;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(Clicked);
        }
    }

    protected virtual void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(Clicked);
        }
    }

    protected virtual void Clicked()
    {
        
    }
}
