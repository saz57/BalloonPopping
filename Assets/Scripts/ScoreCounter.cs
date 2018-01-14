using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score { get; private set; }
    public UIController UIController;

    public void Start()
    {
        Score = 0;
        UIController.ShowScore(Score);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ScoreCounter = this;
    }

    public void AddScore(int score)
    {
        Score += score;
        UIController.ShowScore(Score);
    }
}
