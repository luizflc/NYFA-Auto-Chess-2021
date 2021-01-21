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
}
