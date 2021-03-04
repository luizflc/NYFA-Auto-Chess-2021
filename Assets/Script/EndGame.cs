using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public string thisLevel;

    public void RestartButton()
    {
       SceneManager.LoadScene(thisLevel);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
