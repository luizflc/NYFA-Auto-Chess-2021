using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Text pointText;
    public string thisLevel;

    public void Results()
    {
        gameObject.SetActive(true);
        //pointText.text = score.ToString() + "Score";
    }

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
