using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreLabel;
    public Text HealsLabel;
    public Text ResultTestField;
    public GameObject PauseMenu;
    public GameObject GameEndMenu;
    

    public void Start()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().UIController = this;
    }

    public void ShowHeals(int heals)
    {
        HealsLabel.text = "Heals " + heals.ToString();
    }


    public void ShowScore(int score)
    {
        ScoreLabel.text = "Score " + score.ToString();
    }

    public void ShowPauseMenu(bool show)
    {
        if (!GameManager.GameEnded)
        {
            PauseMenu.SetActive(show);
        }
    }

    public void ShowGameEndMenu(int score)
    {
        GameEndMenu.SetActive(true);
        ResultTestField.text = "Game over. Your score is " + score;
    }
}
