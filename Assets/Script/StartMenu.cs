using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

 public string loadLevel;


// Start is called before the first frame update
void Start()
    {
        
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(loadLevel);
    }

    /* public void StartButton()
     {
         SceneManager.LoadScene("BattleBoard");
     }

     public void CreditsButton()
     {
         SceneManager.LoadScene("Credits");
     } */

     public void QuitButton()
     {
         Application.Quit();
     }

     void Update()
     {
         if (Input.GetKey("escape"))
         {
             Application.Quit();
         }
     }

    public void OnDisable()
    {
        gameObject.SetActive(false);
    }

}
