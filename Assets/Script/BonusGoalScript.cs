using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGoalScript
{
    public BonusGoalObjective myObjective;
    public BonusGoalState myGoalState;
    public int[] goalValues;

    public BonusGoalScript(BonusGoalObjective givenObjective, BonusGoalState startingState)
    {
        startingState = BonusGoalState.Neither;
        myObjective = givenObjective;
        myGoalState = startingState;
    }
public void CheckObjective()
    {
        myGoalState = (BonusGoalState)(goalValues[1] - goalValues[2] / System.Math.Abs(goalValues[1] - goalValues[2]));
        //I wrote some if statements that accomplish the same thing, if my formula messes up. 
        /*
        if (goalValues[1, (int)myObjective] - goalValues[2, (int)myObjective] > 0)
        {
            myGoalState = BonusGoalState.Player1;
        }
        else if(goalValues[1, (int)myObjective] - goalValues[2, (int)myObjective] < 0)
        {
            myGoalState = BonusGoalState.Player2;
        }
        else
        {
            myGoalState = BonusGoalState.Neither;
        }
        */
    } 
    //When calling this method, remember to include the playerNumber. 1 = player, 2 = enemy.
    public void AddGoalValue(BonusGoalObjective thisObjective, int playerNumber)
    {
        if(myObjective == thisObjective) {
            goalValues[playerNumber]++;
        }
        else
        {
            return;
        }
    }
   
}
public enum BonusGoalState
{
    Player2 = -1,
    Neither,
    Player1,
    

}

public enum BonusGoalObjective
{
    mostSpheres,
    mostCubes,
    mostPyramids,
    bestVariety,
    mostGreen,
    mostRed,
    mostPurple,
    mostBlue,
    mostYellow,
    Length
}
//using this enum so we can index an array of values for comparison. The idea is to pass appropriate relative values
//Length is there so we don't need to hard code in the length of the enum. If you add new values, make sure to add them above length.
