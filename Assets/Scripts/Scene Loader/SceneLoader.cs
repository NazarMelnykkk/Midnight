using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private string _systemScene = "SystemScene";
    [SerializeField] private string _menuScene = "Menu";


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
    }

    private void Start()
    {
        Add(_menuScene);
    }

    public void Add(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
    }

    public void Transition(string sceneToLoad, string sceneToUnload)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
    }

    public void RestartGameScene(string sceneToRestart)
    {
        SceneManager.UnloadSceneAsync(sceneToRestart);
        SceneManager.LoadScene(sceneToRestart, LoadSceneMode.Additive);
    }

}
