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
    void Start()
    {
         myPlayable = gameObject.GetComponent<PlayablePiece>();
         dead = false;
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
        transform.position = afterlife;
        myPlayable.canMove = false;
        if(disabling)
        {
            gameObject.SetActive(false);
        }
        
    }
}
