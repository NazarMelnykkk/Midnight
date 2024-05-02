using UnityEngine;

public class ScoreData
{
    public int Wins;
    public int Losses;
}

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance { get; private set; }

    private ScoreData scoreData;

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

        LoadScoreData();
    }

    private void LoadScoreData()
    {
        scoreData = new ScoreData();
        scoreData.Wins = PlayerPrefs.GetInt("Wins", 0);
        scoreData.Losses = PlayerPrefs.GetInt("Losses", 0);
    }

    private void SaveScoreData()
    {
        PlayerPrefs.SetInt("Wins", scoreData.Wins);
        PlayerPrefs.SetInt("Losses", scoreData.Losses);
        PlayerPrefs.Save(); 
    }

    public void IncrementWins()
    {
        scoreData.Wins++;
        SaveScoreData();
    }

    public void IncrementLosses()
    {
        scoreData.Losses++;
        SaveScoreData();
    }

    public ScoreData GetScoreData()
    {
        return scoreData;
    }
}
