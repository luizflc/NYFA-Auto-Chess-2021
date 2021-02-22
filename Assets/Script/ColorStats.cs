using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color", menuName = "Color")]
public class ColorStats : ScriptableObject
{
    public new string name;
    public int dmgRadius;
    public float speed;
    public string direction;
    public BonusGoalObjective objective;
}
