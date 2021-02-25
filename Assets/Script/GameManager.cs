using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PieceSelector storeFront;
    public GameState myState;
    public GameObject UI;
    public int turnNum = 0;
    public float timer;
    public bool canBuy;
    public GameObject textObject;
    public GameObject enemyTextObject;
    public GameObject resultObject;
    public GameObject resultParent;
    public GameObject timerObject;
    public GameObject[] bonusObjects;
    public Text myPlayerText;
    public Text myEnemyText;
    public Text resultText;
    public Text timerText;
    public Text[] bonusTexts;
    public int playerScore;
    public int enemyScore;
    public bool endless;
    public int maxTurns;
    public bool gameOver;
    public Vector3[] playerBench;
    public Vector3[] enemyBench;
    public GameObject enemyHat;
    public BonusGoalScript[] myBonusGoals;
    public System.Random myRandom = new System.Random();
    public static float setTimer = 15f;
    public static int setMaxTurns = 2;
   
    //public GameState state;
    // Start is called before the first frame update
    void Start()
    {
        
        bonusTexts = new Text[3];
        myBonusGoals = new BonusGoalScript[3];
        for (int i = 0; i < myBonusGoals.Length; i++)
        {
            myBonusGoals[i] = new BonusGoalScript((BonusGoalObjective)myRandom.Next(0, (int)BonusGoalObjective.Length-1), 0);
            bonusTexts[i] = bonusObjects[i].GetComponent<Text>();
            bonusTexts[i].text = ("Goal" + " " + (i+1) +" is: " + myBonusGoals[i].myObjective.ToString());
           
        }
        
        myState = GameState.Buy;
        timer = setTimer;
        maxTurns = setMaxTurns;
        myPlayerText = textObject.GetComponent<Text>();
        myEnemyText = enemyTextObject.GetComponent<Text>();
        resultText = resultObject.GetComponent<Text>();
        timerText = timerObject.GetComponent<Text>();
        StartBuyingPhase();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;

           // print(timer);
        }
        if(timer >= 0)
        {
            timerText.text = Mathf.FloorToInt(timer % 60).ToString();
        }
      
        if (timer < 0 && canBuy == false)
        {
            EndBattlePhase();
            StartBuyingPhase();
        }

        myEnemyText.text = "Enemy:" + enemyScore;
        myPlayerText.text = "Player:" + playerScore;
    }
    public void TryGoalAdd(BonusGoalObjective objective, int player)
    {
        for(int i = 0; i < myBonusGoals.Length; i++)
        {
            myBonusGoals[i].AddGoalValue(objective, player);
        }
    }
    public void AwardBonuses()
    {
        for (int i = 0; i < myBonusGoals.Length; i++)
        {
            if(myBonusGoals[i].myGoalState == BonusGoalState.Player1)
            {
                playerScore += 3;
                print("Player 1 awarded 3 bonus points!");
            }
            else if(myBonusGoals[i].myGoalState == BonusGoalState.Player2)
            {
                enemyScore += 3;
                print("Enemy awarded 3 bonus points!");
            }
        }
    }
    public void StartBattlePhase() {
        myState = GameState.Attack;
        timer = setTimer;
        canBuy = false;
        UI.SetActive(false);
        if (turnNum == 0 || turnNum == 1)
        {
            int chooseRand = Random.Range(0, 3);
            if (chooseRand == 0)
            {
                GameObject newPiece = Instantiate(storeFront.pieces[0], new Vector3(Random.Range(21, 25), 1, Random.Range(0, 26)), Quaternion.identity);
                PlayablePiece newPlayable = newPiece.GetComponent<PlayablePiece>();

                newPiece.GetComponent<PieceDeathScript>().afterlife = new Vector3(33, 1, 19.4f);
                newPiece.tag = "EnemyPiece";
                TryGoalAdd(newPlayable.shape.objective, 0);
                TryGoalAdd(newPlayable.color.objective, 0);
                newPiece.name = ("EnemyPiece" + GameObject.FindGameObjectsWithTag("EnemyPiece").Length);
                if (newPlayable.shape.name == "Pyramid")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, 3.5f, 0);
                    hat.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                else if (newPlayable.shape.name == "Sphere")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, .4f, 0);
                    hat.transform.localScale = new Vector3(.5f, .5f, .5f);
                }
                else if (newPlayable.shape.name == "Cube")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, .5f, 0);
                    hat.transform.localScale = new Vector3(.6f, .6f, .6f);
                }
            }
            else if (chooseRand == 1)
            {
                GameObject newPiece = Instantiate(storeFront.pieces[3], new Vector3(Random.Range(21, 25), 1, Random.Range(0, 26)), Quaternion.identity);
                PlayablePiece newPlayable = newPiece.GetComponent<PlayablePiece>();

                newPiece.GetComponent<PieceDeathScript>().afterlife = new Vector3(33, 1, 19.4f);
                newPiece.tag = "EnemyPiece";
                TryGoalAdd(newPlayable.shape.objective, 1);
                TryGoalAdd(newPlayable.color.objective, 1);
                newPiece.name = ("EnemyPiece" + GameObject.FindGameObjectsWithTag("EnemyPiece").Length);
                if (newPlayable.shape.name == "Pyramid")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, 3.5f, 0);
                    hat.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                else if (newPlayable.shape.name == "Sphere")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, .4f, 0);
                    hat.transform.localScale = new Vector3(.5f, .5f, .5f);
                }
                else if (newPlayable.shape.name == "Cube")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, .5f, 0);
                    hat.transform.localScale = new Vector3(.6f, .6f, .6f);
                }
            }
            else if (chooseRand == 2)
            {
                GameObject newPiece = Instantiate(storeFront.pieces[6], new Vector3(Random.Range(21, 25), 1, Random.Range(0, 26)), Quaternion.identity);
                PlayablePiece newPlayable = newPiece.GetComponent<PlayablePiece>();

                newPiece.GetComponent<PieceDeathScript>().afterlife = new Vector3(33, 1, 19.4f);
                newPiece.tag = "EnemyPiece";
                TryGoalAdd(newPlayable.shape.objective, 1);
                TryGoalAdd(newPlayable.color.objective, 1);
                newPiece.name = ("EnemyPiece" + GameObject.FindGameObjectsWithTag("EnemyPiece").Length);
                if (newPlayable.shape.name == "Pyramid")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, 3.5f, 0);
                    hat.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                else if (newPlayable.shape.name == "Sphere")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, .4f, 0);
                    hat.transform.localScale = new Vector3(.5f, .5f, .5f);
                }
                else if (newPlayable.shape.name == "Cube")
                {
                    GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                    hat.transform.parent = newPiece.transform;
                    hat.transform.localPosition = new Vector3(0, .5f, 0);
                    hat.transform.localScale = new Vector3(.6f, .6f, .6f);
                }
            }
        }
        else
        {
            DeployEnemyPieces();
            SpawnEnemyPieces();
        }
        GameObject[] playersObj = GameObject.FindGameObjectsWithTag("PlayerPiece");
        GameObject[] enemyObj = GameObject.FindGameObjectsWithTag("EnemyPiece");
        int numberNeeded = playersObj.Length - enemyObj.Length;
        /*if(numberNeeded < 0)
        {
            numberNeeded *= -1;
        }*/
        if(numberNeeded > 0)
        {
            for(int i = 0; i < numberNeeded; i++)
            {
                SpawnEnemyPieces();
            }
        }
        //state = GameState.PlayerAttack;
    }

    public void StartBuyingPhase()
    {
        myState = GameState.Buy;
        turnNum += 1;
        Economy.instance.p1Corners += 4;
        if(turnNum <= maxTurns + 1 || endless)
        {
            canBuy = true;


            UI.SetActive(true);
            //state = GameState.PlayerBuy;
            storeFront.Refresh();
        }
        else
        {
            GameOver((playerScore-enemyScore));
            gameOver = true;
        }
    }

    public void SpawnEnemyPieces()
    {
        //for (int i = 0; i < turnNum; i++)
        //{
            int pieceNum = Random.Range(0, storeFront.pieces.Length);
            GameObject newPiece = Instantiate(storeFront.pieces[pieceNum], new Vector3(Random.Range(21,25), 1, Random.Range(0,26)), Quaternion.identity);
            PlayablePiece newPlayable = newPiece.GetComponent<PlayablePiece>();

            newPiece.GetComponent<PieceDeathScript>().afterlife = new Vector3(33, 1, 19.4f);
            newPiece.tag = "EnemyPiece";
            TryGoalAdd(newPlayable.shape.objective, 1);
            TryGoalAdd(newPlayable.color.objective, 1);
            newPiece.name = ("EnemyPiece" + GameObject.FindGameObjectsWithTag("EnemyPiece").Length);
            if(newPlayable.shape.name == "Pyramid")
            {
                GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                hat.transform.parent = newPiece.transform;
                hat.transform.localPosition = new Vector3(0, 3.5f, 0);
                hat.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            else if (newPlayable.shape.name == "Sphere")
            {
                GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                hat.transform.parent = newPiece.transform;
                hat.transform.localPosition = new Vector3(0, .4f, 0);
                hat.transform.localScale = new Vector3(.5f, .5f, .5f);
            }
            else if(newPlayable.shape.name == "Cube")
            {
                GameObject hat = Instantiate(enemyHat, Vector3.zero, Quaternion.identity);
                hat.transform.parent = newPiece.transform;
                hat.transform.localPosition = new Vector3(0, .5f, 0);
                hat.transform.localScale = new Vector3(.6f, .6f, .6f);
            }
        //}
    }

    public void DeployEnemyPieces()
    {
        GameObject[] enemyPieces = GameObject.FindGameObjectsWithTag("EnemyPiece");
        for (int i = 0; i < enemyPieces.Length; i++)
        {
            enemyPieces[i].transform.position = new Vector3(Random.Range(21, 25), 1, Random.Range(0, 26));
        }
    }
    // The way you would call this method is this: GameOver((playerScore - enemyScore));.
    public void GameOver(int score)
    {
        resultParent.SetActive(true);
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
            if(i < playerBench.Length)
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
            if (i < enemyBench.Length)
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
