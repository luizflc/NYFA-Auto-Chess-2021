using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //Author: Jordan Barboza


    public bool PlayerOneWin;
    public bool PlayerTwoWin;

    public int playerOneScore;
    public int playerTwoScore;


    // Start is called before the first frame update
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOneWin == true)
        {
            playerOneScore += 1;
            PlayerOneWin = false;
        }

        if (PlayerTwoWin == true)
        {
            playerTwoScore += 1;
            PlayerTwoWin = false;
        }
    }
}
