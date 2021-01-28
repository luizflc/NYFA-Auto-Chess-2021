using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PieceSelector storeFront;
    public GameObject UI;
    public int turnNum = 0;
    public float timer;
    public bool canBuy;
    //public GameState state;
    // Start is called before the first frame update
    void Start()
    {
        StartBuyingPhase();
        timer = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
            print(timer);
        }
        if (timer < 0 && canBuy == false)
        {
            StartBuyingPhase();
        }
    }

    public void StartBattlePhase() {
        timer = 15;
        UI.SetActive(false);
        SpawnEnemyPieces();
        //state = GameState.PlayerAttack;
    }

    public void StartBuyingPhase()
    {
        canBuy = true;
        turnNum += 1;
        UI.SetActive(true);
        //state = GameState.PlayerBuy;
        storeFront.Refresh();
    }

    public void SpawnEnemyPieces()
    {
        for (int i = 0; i < turnNum; i++)
        {
            int pieceNum = Random.Range(0, storeFront.pieces.Length);
            GameObject newPiece = Instantiate(storeFront.pieces[pieceNum], new Vector3(Random.Range(21,25), 1, Random.Range(0,26)), Quaternion.identity);
            newPiece.tag = "EnemyPiece";
            newPiece.name = ("EnemyPiece" + GameObject.FindGameObjectsWithTag("EnemyPiece").Length);
        }
    }
}
