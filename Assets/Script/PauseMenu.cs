using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string thisLevel;
    public GameObject pauseMenu;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        thisLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        //player input to display pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
            if (isPaused)
            {
                //freezes game if paused
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RetryGame()
    {
        //reloads scene
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(thisLevel);
    }

    public void MainMenu()
    {
        //load game back to menu
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
