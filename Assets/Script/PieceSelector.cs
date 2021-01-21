using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelector : MonoBehaviour
{
    public Vector3[] piecePositions;
    public GameObject[] pieces;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Refresh();
        } 
    }

    public void Refresh()
    {
        int pieceNum;
        for(int i = 0; i <= piecePositions.Length; i++)
        {
            pieceNum = Random.Range(0, pieces.Length);
            Instantiate(pieces[pieceNum], piecePositions[i], Quaternion.identity);
        }
    }
}
