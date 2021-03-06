﻿using System.Collections;
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
    public NeutralArea myNeutral;
    public bool inNeutralArea = false;
    void Start()
    {
         myPlayable = gameObject.GetComponent<PlayablePiece>();
         myNeutral = GameObject.Find("Neutral Ground").GetComponent<NeutralArea>();
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
        print(gameObject.name + "has died!");
        if (gameObject.tag == "EnemyPiece")
        {
            myManager.playerScore++;
            if (inNeutralArea)
            {
                myNeutral.ForcedEnemyExit();
            }
            if(myPlayable.color.name == "Purple")
            {
                print("purpledeathbonus");
                myManager.playerScore += 2;
            }
            
        }
        else if (gameObject.tag == "PlayerPiece") 
            {
            myManager.enemyScore++;
            if (inNeutralArea)
            {
                myNeutral.ForcedPlayerExit();
            }
            if(myPlayable.color.name == "Purple")
            {
                print("purpledeathbonusEnemy");
                myManager.playerScore += 2;
            }

            } 

        transform.position = afterlife;
        myPlayable.canMove = false;
        inNeutralArea = false;
        myPlayable.health = myPlayable.shape.health;
        if(disabling)
        {
            gameObject.SetActive(false);
        }
        
    }
}
