using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class GameResult
{
    public int Score;
    public string Nickname;

    public GameResult()
    { }
}

public static class GameResultsSerializer
{
    public static int ResultsSize = 10;
    public static string FileName = "results.xml";

    static GameResultsSerializer()
    {/*
#if UNITY_ANDROID && !UNITY_EDITOR      
        FileName = "jar:file://" + Application.dataPath + "!/assets/" + FileName);
#endif*/
    }

    public static void SaveResult(GameResult gameResult)
    {
        List<GameResult> gameResults = new List<GameResult>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<GameResult>));

        using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate))
        {
            if (fileStream.Length > 0)
            {
                gameResults = (List<GameResult>)serializer.Deserialize(fileStream);

                for (int i = 0; i < gameResults.Count; i++)
                {
                    if (gameResult.Score > gameResults[i].Score)
                    {
                        gameResults.Insert(i, gameResult);
                        break;
                    }
                }

                if (gameResults.Count > ResultsSize)
                {
                    while (gameResults.Count > ResultsSize)
                    {
                        gameResults.RemoveAt(gameResults.Count - 1);
                    }
                }
            }

            else
            {
                gameResults.Add(gameResult);
            }

            fileStream.Seek(0, SeekOrigin.Begin);
            serializer.Serialize(fileStream, gameResults);
        }
    }

    public static List<GameResult> LoadResult()
    {
        List<GameResult> gameResults = new List<GameResult>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<GameResult>));

        using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate))
        {
            if (fileStream.Length > 0)
            {
                gameResults = (List<GameResult>)serializer.Deserialize(fileStream);
            }
        }

        return gameResults;
    }
}
