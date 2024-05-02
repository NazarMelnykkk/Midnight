using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    [Header("PupUp Components")]
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _container;

    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private TextMeshProUGUI _score;

    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _restartButton;


    private void OnEnable()
    {
        InputController.Instance.OnMenuEventPerformed += Open;

        GameEventController.Instance.GameEvents.OnEnemyKilledEvent += WinPopUp;
        GameEventController.Instance.GameEvents.OnPlayerKilledEvent += LosePopUp;

        _menuButton.onClick.AddListener(Menu);
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        InputController.Instance.OnMenuEventPerformed -= Open;

        GameEventController.Instance.GameEvents.OnEnemyKilledEvent -= WinPopUp;
        GameEventController.Instance.GameEvents.OnPlayerKilledEvent -= LosePopUp;

        _menuButton.onClick.RemoveListener(Menu);
        _restartButton.onClick.RemoveListener(RestartGame);
    }

    private void Open()
    {
        _container.SetActive(!_container.activeSelf);

        if(_container.activeSelf == true)
        {
            _gameController.CursorVisible(true);
        }
        else
        {
            _gameController.CursorVisible(false);
        }

        _score.text = $"wins: {ScoreController.Instance.GetScoreData().Wins} losses: {ScoreController.Instance.GetScoreData().Losses}";
    }

    private void LosePopUp()
    {
        _label.text = "You Lose";
        ScoreController.Instance.IncrementLosses();

        Open();

        InputController.Instance.OnMenuEventPerformed -= Open;
    }

    private void WinPopUp()
    {
        _label.text = "You Win";
        ScoreController.Instance.IncrementWins();

        Open();

        InputController.Instance.OnMenuEventPerformed -= Open;
    }

    private void Menu()
    {
        SceneLoader.Instance.Transition("Menu", gameObject.scene.name);
    }

    private void RestartGame()
    {
        SceneLoader.Instance.RestartGameScene(gameObject.scene.name);
    }
}
