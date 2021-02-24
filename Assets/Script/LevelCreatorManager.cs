using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCreatorManager : MonoBehaviour
{
    public int timer;
    public Text timerText;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        nextScene = null;
        timer = 15;
        timerText.text = "15";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTimer()
    {
        timer += 1;
        if(timer > 60)
        {
            timer = 60;
        }
        timerText.text = timer.ToString();
    }
    public void SubtractToTimer()
    {
        timer -= 1;
        if(timer < 5)
        {
            timer = 5;
        }
        timerText.text = timer.ToString();
    }
    public void SetNextSceneTo(string sceneName)
    {
        nextScene = sceneName;
    }
    public void StartGame()
    {
        GameManager.setTimer = timer;
        SceneManager.LoadScene(nextScene);

    }
}
