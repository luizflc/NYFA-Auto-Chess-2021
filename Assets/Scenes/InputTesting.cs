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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gamePhases.playerState = BattlePhases.GameState.PlayerAttack;
        }
    }
}
