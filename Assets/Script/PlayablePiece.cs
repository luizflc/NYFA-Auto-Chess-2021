using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayablePiece : MonoBehaviour
{
    public ColorStats color;
    public ShapeStats shape;
    // Start is called before the first frame update
    public int damage;
    public int health;
    public int cost;
    public int dmgRadius;
    public int speed;
    void Start()
    {
        damage = shape.damage;
        health = shape.health;
        cost = shape.cost;
        dmgRadius = color.dmgRadius;
        speed = color.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
