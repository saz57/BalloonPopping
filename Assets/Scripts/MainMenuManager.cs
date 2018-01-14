using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ResultTableMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        ResultTableMenu.SetActive(false);
    }

    public void ShowTableMenu()
    {
        MainMenu.SetActive(false);
        ResultTableMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
