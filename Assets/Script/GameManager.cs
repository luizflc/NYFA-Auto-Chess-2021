using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PieceSelector storeFront;
    public GameObject UI;
    //public GameState state;
    // Start is called before the first frame update
    void Start()
    {
        StartBuyingPhase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattlePhase() {
        UI.SetActive(false);
        //state = GameState.PlayerAttack;
    }

    public void StartBuyingPhase()
    {
        UI.SetActive(true);
        //state = GameState.PlayerBuy;
        storeFront.Refresh();
    }
}
