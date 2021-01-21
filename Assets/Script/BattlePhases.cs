using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePhases : MonoBehaviour
{
    public enum GameState { PlayerSelect, PlayerAttack };

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
            case GameState.PlayerSelect:
                Debug.Log("Player is selecting");
                break;
            case GameState.PlayerAttack:
                Debug.Log("Player is attacking");
                break;
        }
    }
}
