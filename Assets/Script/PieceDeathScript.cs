using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDeathScript : MonoBehaviour
{
    //Author: Luke Sapir

    public PlayablePieceV2 myPlayable;
    bool dead;
    public Vector3 afterlife;
    public GameObject Graveyard;
    public bool disabling;
    public GameObject myManagerObject;
    public DragScript myDragScript;
    public GameManager myManager;
    public NeutralArea myNeutral;
    public GameObject myExplosion;
    public PauseMenu myPause;
    public bool inNeutralArea = false;
    void Start()
    {
        myPlayable = gameObject.GetComponent<PlayablePieceV2>();
        myNeutral = GameObject.Find("Neutral Ground").GetComponent<NeutralArea>();
        dead = false;
        myPause = GameObject.Find("PauseUI").GetComponent<PauseMenu>();
        myManagerObject = GameObject.Find("GameManager");
        myManager = myManagerObject.GetComponent<GameManager>();
        /*if (Graveyard == null)
        {
            afterlife = new Vector3(10, 10, 10);
        }
        else
        {
            afterlife = Graveyard.transform.position;
        }*/
    }


    void Update()
    {
        if (myPlayable.health <= 0 /*&& dead == false*/)
        {
            Death();
        }
    }
    void Death()
    {
        dead = true;
        print(gameObject.name + "has died!");
        if (gameObject.tag == "EnemyPiece")
        {
            myManager.playerScore++;
            if (inNeutralArea)
            {
                myNeutral.ForcedEnemyExit();
            }
            /*
            if(myPlayable.color.name == "Purple")
            {
                print("purpledeathbonus");
                myManager.playerScore += 2;
            }
            */
        }
        else if (gameObject.tag == "PlayerPiece")
        {
            myManager.enemyScore++;
            if (inNeutralArea)
            {
                myNeutral.ForcedPlayerExit();
            }
            /*
            if(myPlayable.color.name == "Purple")
            {
                print("purpledeathbonusEnemy");
                myManager.playerScore += 2;
            }
            */
        }
        GameObject.Instantiate(myExplosion, transform.position + Vector3.up, Quaternion.identity);
        transform.position = afterlife;
        myPlayable.canMove = false;
        inNeutralArea = false;
        myPlayable.health += 1;
        if (gameObject.name == "PlayerBase")
        {
                myManager.GameOver(-1);
                Time.timeScale = 0;
                myPause.isPaused = true;
            
            
        }
        if(gameObject.name == "EnemyBase")
        {
            myManager.GameOver(1);
            Time.timeScale = 0;
            myPause.isPaused = true;
        }
        if(disabling)
        {
            gameObject.SetActive(false);
        }
        
    }
}
