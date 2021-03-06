using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shape", menuName = "Shape")]
public class ShapeStats : ScriptableObject
{
    public new string name;
    public int damage;
    public int health;
    public int cost;

    //Shape Stat Changes added 3/3/2021
    /*
    public int dmgRadius;
    public float speed;
    public string direction;
    */
    public BonusGoalObjective objective;
}
