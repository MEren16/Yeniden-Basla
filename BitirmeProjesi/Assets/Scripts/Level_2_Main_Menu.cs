using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2MainMenu : MonoBehaviour
{
    public GameObject araMenuPanel;

    public void PlayGame()
    {
       araMenuPanel.SetActive(false);

       Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
