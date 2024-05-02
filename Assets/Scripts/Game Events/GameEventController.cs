using UnityEngine;

public class GameEventController : MonoBehaviour
{
    public static GameEventController Instance { get; private set; }

    public GameEvents GameEvents;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GameEvents = new GameEvents();
    }
}
