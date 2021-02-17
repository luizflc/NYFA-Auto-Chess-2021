using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGoalScript
{
    public BonusGoalObjective myObjective;
    public BonusGoalState myGoalState;
    public int[] goalValues;
public void CheckObjective()
    {
        switch (myObjective)
        {
            case mostSpheres:
                break;

        }
    } 
    public void AddGoalValue(BonusGoalObjective thisObjective)
    {
        goalValues[thisObjective]++;
    }
   
}
public enum BonusGoalState
{
    Player1,
    Player2,
    Neither
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
    mostYellow
}
//using this enum so we can index an array of values for comparison. The idea is to pass appropriate relative values 
