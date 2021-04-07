using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerV2 : MonoBehaviour
{
    public GameObject[] Pieces;
    public Vector3[] startPoints;
    public int roundNum;
   /// public float timerStart;
   // float timer;
   // public int score;
    //public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        roundNum = 1;
  //      timer = timerStart;
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
           // timerText.text = Mathf.FloorToInt(timer % 60).ToString();
        }
       else if(timer <= 0f)
        {
            timer = timerStart;
            EndRound();
        } 
        */
    }

    public void StartRound() {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        for(int i = 0; i < roundNum; i++)
        {
            int pieceNum = Random.Range(0, Pieces.Length);
            print("Piece num is " + pieceNum);
            int startPos = Random.Range(0, startPoints.Length);
            print("StartPos num is " + startPos);
            GameObject newEnemyPiece = Instantiate(Pieces[pieceNum], startPoints[startPos], Quaternion.Euler(-90,-90,0));
            newEnemyPiece.tag = "EnemyPiece";
        }
    }

    public void EndRound()
    {
        GameObject[] playersPieces = GameObject.FindGameObjectsWithTag("PlayerPiece");
        /*for(int i = 0; i < playersPieces.Length; i++)
        {
            Destroy(playersPieces[i]);
        }*/
        roundNum += 1;
    }
}
