using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDeathScript : MonoBehaviour
{
    //Author: Luke Sapir

    public PlayablePiece myPlayable;
    bool dead;
    public Vector3 afterlife;
    public GameObject Graveyard;
    public bool disabling;
    public GameObject myManagerObject;
    public DragScript myDragScript;
    public GameManager myManager;
    void Start()
    {
         myPlayable = gameObject.GetComponent<PlayablePiece>();
         dead = false;
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
     if(myPlayable.health <= 0 /*&& dead == false*/)
        {
            Death();
        }   
    }
    void Death()
    {
        dead = true;
        if(gameObject.tag == "EnemyPiece")
        {
            myManager.playerScore++;

        }
        else if (gameObject.tag == "PlayerPiece") 
            {
            myManager.enemyScore++;

            } 

        transform.position = afterlife;
        myPlayable.canMove = false;
        myPlayable.health = myPlayable.shape.health;
        if(disabling)
        {
            gameObject.SetActive(false);
        }
        
    }
}
