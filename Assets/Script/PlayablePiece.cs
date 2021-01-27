using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayablePiece : MonoBehaviour
{
    

    public ColorStats color;
    public ShapeStats shape;
    // Start is called before the first frame update
    public bool goingForward;
    public bool sideStrafe;
    bool canMoveSideways;
    bool canMoveForwards;
    public int damage;
    public int health;
    public int cost;
    public int dmgRadius;
    public float speed;
    public int maxX;
    public int minX;
    public int maxZ;
    public int minZ;
    public bool canMove;
    void Start()
    {
        goingForward = true;
        damage = shape.damage;
        health = shape.health;
        cost = shape.cost;
        dmgRadius = color.dmgRadius;
        speed = color.speed;
        if (color.name == "Red")
        {
            canMoveSideways = false;
            canMoveForwards = true;
        }

        if (color.name == "Blue")
        {
            canMoveSideways = true;
            canMoveForwards = true;
        }

        if (color.name == "Yellow")
        {
            canMoveSideways = false;
            canMoveForwards = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (canMoveForwards == true)
            {
                if (goingForward == true)
                {
                    if (gameObject.transform.position.x <= maxX)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z);
                    }
                    else
                    {
                        goingForward = false;
                    }
                }

                if (goingForward == false)
                {
                    if (gameObject.transform.position.x >= minX)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
                    }
                    else
                    {
                        goingForward = true;
                    }
                }
            }
            if (canMoveSideways == true)
            {
                if (sideStrafe == true)
                {
                    if (gameObject.transform.position.z <= maxZ)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + speed);
                    }
                    else
                    {
                        sideStrafe = false;
                    }
                }
                if (sideStrafe == false)
                {
                    if (gameObject.transform.position.z >= minZ)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - speed);
                    }
                    else
                    {
                        sideStrafe = true;
                    }
                }
            }
        }
    }


 }

