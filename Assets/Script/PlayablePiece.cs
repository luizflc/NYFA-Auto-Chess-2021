using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayablePiece : MonoBehaviour
{

    // Start is called before the first frame update
    public ColorStats color;
    public ShapeStats shape;
    public bool goingForward;
    public bool sideStrafe;
    bool canMoveSideways;
    bool canMoveForwards;
    public int damage;
    public int health;
    public int cost;
    public int dmgRadius;
    public float speed;
    public float scoreTimer;
    public int maxX;
    public int minX;
    public int maxZ;
    public int minZ;
    public bool canMove;
    public GameObject myManagerObject;
    public GameManager myManager;
    public PauseMenu MyPause;

    void Start()
    {
        MyPause = GameObject.Find("PauseUI").GetComponent<PauseMenu>();
        myManagerObject = GameObject.Find("GameManager");
        myManager = myManagerObject.GetComponent<GameManager>();
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
            canMoveSideways = true;
            canMoveForwards = false;
        }
        if (color.name == "Purple")
        {
            scoreTimer += 5;
            canMove = true;
            int direction = Random.Range(1, 4);
            if(direction == 1)
            {
                canMoveSideways = true;
                canMoveForwards = false;
            }
            else if (direction == 2)
            {
                canMoveForwards = true;
                canMoveSideways = false;
            }
            else
            {
                canMoveForwards = true;
                canMoveSideways = true;
            }
        }
        if(color.name == "Green")
        {
            canMoveForwards = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(MyPause.isPaused)
        {
            return;
        }
        if(scoreTimer > 0 || myManager.myState != GameState.Attack)
        {
            scoreTimer = scoreTimer - Time.deltaTime;
        }
        else if(color.name == "Purple" && gameObject.tag == "PlayerPiece")
        {
            myManager.playerScore++;
            print ("purplebonus");
            scoreTimer += 5;
            
        }
        else if(color.name == "Purple" && gameObject.tag == "EnemyPiece")
        {
            myManager.enemyScore++;
            print("purplebonus");
            scoreTimer += 5;
        }
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

