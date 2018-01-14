using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTableController : MonoBehaviour
{
    public Text Output;

    public void OnEnable()
    {
        List<GameResult> gameResults = GameResultsSerializer.LoadResult();
        Output.text = string.Empty;

        foreach(var gameResult in gameResults)
        {
            Output.text += gameResult.Nickname + " " + gameResult.Score + "\n";
        }
        
    }
}
