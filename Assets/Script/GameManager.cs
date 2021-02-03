using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PieceSelector storeFront;
    public GameObject UI;
    public int turnNum = 0;
    public float timer;
    public bool canBuy;
    public GameObject textObject;
    public GameObject enemyTextObject;
    public GameObject resultObject;
    public Text myPlayerText;
    public Text myEnemyText;
    public Text resultText;
    public int playerScore;
    public int enemyScore;
    public bool endless;
    public int maxTurns;
    public Vector3[] playerBench;
    public Vector3[] enemyBench;
   
    //public GameState state;
    // Start is called before the first frame update
    void Start()
    {
        timer = 15f;
        myPlayerText = textObject.GetComponent<Text>();
        myEnemyText = enemyTextObject.GetComponent<Text>();
        resultText = resultObject.GetComponent<Text>();
        StartBuyingPhase();
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

        myEnemyText.text = "Enemy:" + enemyScore;
        myPlayerText.text = "Player:" + playerScore;
    }

    public void StartBattlePhase() {
        timer = 15;
        canBuy = false;
        UI.SetActive(false);
        SpawnEnemyPieces();
        //state = GameState.PlayerAttack;
    }

    public void StartBuyingPhase()
    {
        turnNum += 1;
        if(turnNum <= maxTurns || endless)
        {
            canBuy = true;


            UI.SetActive(true);
            //state = GameState.PlayerBuy;
            storeFront.Refresh();
        }
        else
        {
            GameOver(playerScore-enemyScore);
        }
    }

    public void SpawnEnemyPieces()
    {
        for (int i = 0; i < turnNum; i++)
        {
            int pieceNum = Random.Range(0, storeFront.pieces.Length);
            GameObject newPiece = Instantiate(storeFront.pieces[pieceNum], new Vector3(Random.Range(21,25), 1, Random.Range(0,26)), Quaternion.identity);
            newPiece.GetComponent<PieceDeathScript>().afterlife = new Vector3(33, 1, 20);
            newPiece.tag = "EnemyPiece";
            newPiece.name = ("EnemyPiece" + GameObject.FindGameObjectsWithTag("EnemyPiece").Length);
        }
    }
    // The way you would call this method is this: GameOver((playerScore - enemyScore));.
    public void GameOver(int score)
    {
        resultObject.SetActive(true);
        if (score > 0)
        {
            resultText.text = "Player 1 wins.";
        }
        else if (score < 0)
        {
            resultText.text = "Player 2 wins.";
        }
        else
        {
            resultText.text = "Draw";
        }
        
    }

    public void EndBattlePhase()
    {
        GameObject[] playerPieces = GameObject.FindGameObjectsWithTag("PlayerPiece");
        for (int i = 0; i < playerPieces.Length; i++)
        {
            if(i <= playerBench.Length)
            {
                playerPieces[i].transform.position = playerBench[i];
            }
            else
            {
                Destroy(playerPieces[i]);
            }
        }

        GameObject[] enemyPieces = GameObject.FindGameObjectsWithTag("EnemyPiece");
        for (int i = 0; i < enemyPieces.Length; i++)
        {
            if (i <= enemyBench.Length)
            {
                enemyPieces[i].transform.position = enemyBench[i];
            }
            else
            {
                Destroy(enemyPieces[i]);
            }
        }

    }
}
