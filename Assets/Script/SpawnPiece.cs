﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    public GameObject piece;
    public GameObject[] otherButtons;
    //public int currPiece;
    public Vector3[] benchLocations;
    public Transform[] benchTransforms;
    public Vector3 spawnLocation;
    public GameObject playerHat;
    public GameManager myManager;
    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        for(int i = 0; i < benchLocations.Length; i++)
        {
            benchLocations[i] = benchTransforms[i].position; 

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        print("Button was pusheded");
       //if(Economy.instance.p1Corners >= pieces[currPiece].GetComponent<PlayablePiece>().shape.cost){
            GameObject[] playerPieces = GameObject.FindGameObjectsWithTag("PlayerPiece");
            if (playerPieces.Length < benchLocations.Length)
            {
                spawnLocation = benchLocations[playerPieces.Length];
            }
            else
            {
                spawnLocation = benchLocations[0];
            }
            GameObject newPiece = Instantiate(piece, spawnLocation, Quaternion.Euler(-90,90,0));
        //newPiece.SetActive(false);
            print("Object should have been instantiated");
            if(piece.name == "SmallPieceEnemy")
        {
            newPiece.transform.position = new Vector3(newPiece.transform.position.x, newPiece.transform.position.y + 3, newPiece.transform.position.z);
        }
            //print("Subtracting: " + newPiece.GetComponent<PlayablePiece>().shape.cost + " corners");
            //Economy.instance.SubtractCorners(newPiece.GetComponent<PlayablePiece>().shape.cost);
            newPiece.tag = "PlayerPiece";
            newPiece.name = ("PlayerPiece" + GameObject.FindGameObjectsWithTag("PlayerPiece").Length);
            //PlayablePiece spawnPlayable = newPiece.GetComponent<PlayablePiece>();
            //myManager.TryGoalAdd(spawnPlayable.color.objective, 1);
            //myManager.TryGoalAdd(spawnPlayable.shape.objective, 1);
            newPiece.AddComponent<ClickToTarget>();
            newPiece.GetComponent<PieceDeathScript>().afterlife = spawnLocation;
            myManager.buyablePieceNum -= 1;
            myManager.buyablePieces[myManager.buyablePieceNum].SetActive(false);
        
            /*if (newPiece.GetComponent<PlayablePiece>().shape.name == "Pyramid")
            {
                GameObject hat = Instantiate(playerHat, Vector3.zero, Quaternion.identity);
                hat.transform.parent = newPiece.transform;
                hat.transform.localPosition = new Vector3(0, 3, 0);
                hat.transform.localScale = new Vector3(.4f, .4f, .4f);
            }
            else if (newPiece.GetComponent<PlayablePiece>().shape.name == "Sphere")
            {
                GameObject hat = Instantiate(playerHat, Vector3.zero, Quaternion.identity);
                hat.transform.parent = newPiece.transform;
                hat.transform.localPosition = new Vector3(0, .4f, 0);
                hat.transform.localScale = new Vector3(.2f, .2f, .2f);
            }
            else if (newPiece.GetComponent<PlayablePiece>().shape.name == "Cube")
            {
                GameObject hat = Instantiate(playerHat, Vector3.zero, Quaternion.identity);
                hat.transform.parent = newPiece.transform;
                hat.transform.localPosition = new Vector3(0, .5f, 0);
                hat.transform.localScale = new Vector3(.2f, .2f, .2f);
            }*/
            //SynergyBonuses.instance.UpdateSynergies();
            //gameObject.transform.parent.GetComponent<PieceSelector>().Refresh();
        //}
        //else
        //{
          //  gameObject.SetActive(false);
        //}
    }
}
