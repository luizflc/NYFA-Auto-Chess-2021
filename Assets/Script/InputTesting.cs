using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTesting : MonoBehaviour
{
    private BattlePhases gamePhases;
    // Start is called before the first frame update
    void Start()
    {
        gamePhases = GetComponent<BattlePhases>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePhases.playerState == BattlePhases.GameState.PlayerSelect && Input.GetKeyDown(KeyCode.Y))
        {
            gamePhases.playerState = BattlePhases.GameState.PlayerBuy;
        }
        else if(gamePhases.playerState == BattlePhases.GameState.PlayerSelect && Input.GetKeyDown(KeyCode.N))
        {
            gamePhases.playerState = BattlePhases.GameState.PlayerAttack;
        }
        else if (gamePhases.playerState == BattlePhases.GameState.PlayerBuy && Input.GetKeyDown(KeyCode.A)) 
        {
            gamePhases.playerState = BattlePhases.GameState.PlayerAttack;
        }
        /*else if (Input.GetKeyDown(KeyCode.Space))
        {
            gamePhases.playerState = BattlePhases.GameState.PlayerAttack;
        }
        */
    }
}
