using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject[] otherButtons;
    public int currPiece;
    public Vector3 spawnLocation;
    public GameObject playerHat;
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
        if (newPiece.GetComponent<PlayablePiece>().shape.name == "Pyramid")
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
            hat.transform.localPosition = new Vector3(0,.5f,0);
            hat.transform.localScale = new Vector3(.2f, .2f, .2f);
        }
        for (int i = 0; i < otherButtons.Length; i++)
        {
            otherButtons[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
