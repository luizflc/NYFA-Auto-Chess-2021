using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject[] otherButtons;
    public int currPiece;
    public Vector3 spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject newPiece = Instantiate(pieces[currPiece], spawnLocation, Quaternion.identity);
        newPiece.tag = "PlayerPiece";
        newPiece.name = ("PlayerPiece" + GameObject.FindGameObjectsWithTag("PlayerPiece").Length);
        for(int i = 0; i < otherButtons.Length; i++)
        {
            otherButtons[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
