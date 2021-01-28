using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePhases : MonoBehaviour
{
    //public enum GameState { PlayerSelect, PlayerBuy, PlayerAttack };
    public GameState playerState;
    //public int playerTurnID;
    //public int nextPlayerID;
    void Start()
    {
        /*if(GlobalData.instance.playerID == 0)
        {

        }
        */
    }

    
    void Update()
    {
        switch(playerState)
        {
            case GameState.Select:
                Debug.Log("Player is selecting");
                break;
            case GameState.Buy:
                Debug.Log("Player is buying");
                break;
            case GameState.Attack:
                Debug.Log("Player is attacking");
                break;
        }
    }
}
public enum GameState { 
Select,
Buy,
Attack
}
