using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralArea : MonoBehaviour
{
    public GameManager myManager;
    public int owner;
    public int playerOccupants;
    public int enemyOccupants;
    public int occupants;
    public float scoreTimer;
    public Light myLight;
    public Color playerColor;
    public Color enemyColor;
    // Start is called before the first frame update
    void Start()
    {
        owner = 0;
        if(scoreTimer == 0)
        {
            scoreTimer = 5f;
        }
        
        myManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreTimer > 0 && myManager.myState == GameState.Attack)
        {
            scoreTimer -= 1 * Time.deltaTime;
        }
        else if(myManager.myState != GameState.Attack)
        {
            scoreTimer = 5f;
        }
        else
        {
            if (owner < 1)
            {
                scoreTimer = 5f;
                return;
            }
            else if (owner == 1)
            {
                scoreTimer = 5f;
                myManager.playerScore ++;
                print("Player score from neutral area!");
            }
            else if (owner == 2)
            {
                scoreTimer = 5f;
                myManager.enemyScore++;
                print("Enemy score from neutral area!");
            }
        }
      
    }
    public void OnTriggerStay(Collider other)
    {
     
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerPiece")
        {
            playerOccupants--;
            other.GetComponent<PieceDeathScript>().inNeutralArea = false;
            if (enemyOccupants > 0)
            {
                owner = 2;
                
                print("Enemy now controls the neutral area.");
                myLight.color = enemyColor;
            }
        }
        else if(other.tag == "EnemyPiece")
        {
            enemyOccupants--;
            other.GetComponent<PieceDeathScript>().inNeutralArea = false;
            if (playerOccupants > 0)
            {
                owner = 1;
                print("Player now controls the neutral area.");
                myLight.color = playerColor;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerPiece")
        {
            playerOccupants++;
            other.GetComponent<PieceDeathScript>().inNeutralArea = true;
            if (enemyOccupants == 0)
            {
                owner = 1;
                print("Player now controls the neutral area.");
                myLight.color = playerColor;
            }
        }
        if(other.tag == "EnemyPiece")
        {
            enemyOccupants++;
            other.GetComponent<PieceDeathScript>().inNeutralArea = true;
            if (playerOccupants == 0)
            {
                owner = 2;
                print("Enemy now controls the neutral area.");
                myLight.color = enemyColor;
            }
        }
    }
    public void ForcedPlayerExit()
    {
        if (playerOccupants > 0)
        {
            playerOccupants--;
        }
    }
    public void ForcedEnemyExit()
    {
        if(enemyOccupants > 0)
        {
            enemyOccupants--;
        }
    }
}
