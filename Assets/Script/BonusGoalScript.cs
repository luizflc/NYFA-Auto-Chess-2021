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
        goalValues = new int[2];
        goalValues[0] = 0;
        goalValues[1] = 0;
    }
public void CheckObjective()
    {
        myGoalState = (BonusGoalState)(goalValues[0] - goalValues[1] / System.Math.Abs(goalValues[0] - goalValues[1]));
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
    //When calling this method, remember to include the playerNumber. 0 = player, 1 = enemy.
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
    Spheres,
    Cubes,
    Pyramids,
    Variety,
    Green,
    Red,
    Purple,
    Blue,
    Yellow,
    Length
}
//using this enum so we can index an array of values for comparison. The idea is to pass appropriate relative values
//Length is there so we don't need to hard code in the length of the enum. If you add new values, make sure to add them above length.
