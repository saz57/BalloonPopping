using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UIController UIController { private get; set; }
    public ScoreCounter ScoreCounter { private get; set; }

    public static bool IsPaused;
    public static bool GameEnded;

    public void Start()
    {
        Time.timeScale = 1;
        IsPaused = false;
        GameEnded = false;
    }

    public void EndGame()
    {
        GameEnded = true;
        UIController.ShowGameEndMenu(ScoreCounter.Score);
    }
    
    public void Pause()
    {
        if (!GameEnded)
        {
            if (IsPaused)
            {
                Time.timeScale = 1;
            }

            else
            {
                Time.timeScale = 0;
            }

            IsPaused = !IsPaused;
            UIController.ShowPauseMenu(IsPaused);
        }
    }

    public void Restart()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveResult(InputField nickNameField)
    {
        GameResultsSerializer.SaveResult(new GameResult() { Nickname = nickNameField.text, Score = ScoreCounter.Score });
        SceneManager.LoadScene("MainMenu");
    }
}
