using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMoving : MonoBehaviour
{
    public float speed;
    public int maxX;
    public int maxZ;
    public int minX;
    public int minZ;
    public bool canMove;
    public bool goingForward;
    public bool sideStrafe;
    bool canMoveSideways;
    bool canMoveForwards;
    public float timerStart;
    float timer;
    public PieceType type;
    public bool moveForward;
    public bool moveBackward;
    public bool moveRight;
    public bool moveLeft;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime * speed;
        }
        else
        {
            Move();
            timer = timerStart;
        }
    }
    public void Move()
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
            /*int moveDirection = Random.Range(0, 4);
            if(gameObject.transform.position.x >= maxX)
            {
                moveDirection = 2;
            }
            else if(gameObject.transform.position.x <= minX)
            {
                moveDirection = 0;
            }
            else if (gameObject.transform.position.z >= maxZ)
            {
                moveDirection = 1;
            }
            else if (gameObject.transform.position.z <= minZ)
            {
                moveDirection = 3;
            }
            else
            {
                moveDirection = moveDirection;
            }
            if(moveDirection == 0)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if(moveDirection == 1)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 5);
            }
            else if (moveDirection == 2)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if (moveDirection == 3)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 5);
            }
            else
            {
                gameObject.transform.position = gameObject.transform.position;
            }*/
            /*if (gameObject.transform.position.x <= minX)
             {
                 moveForward = true;
                 moveBackward = false;
                 moveLeft = false;
                 moveRight = false;
             }
             else if (gameObject.transform.position.x >= maxX)
             {
                 moveForward = false;
                 moveBackward = true;
                 moveLeft = false;
                 moveRight = false;
             }
             else if (gameObject.transform.position.z <= minZ)
             {
                 moveForward = false;
                 moveBackward = false;
                 moveLeft = false;
                 moveRight = true;
             }
             else if (gameObject.transform.position.z >= maxZ)
             {
                 moveForward = false;
                 moveBackward = false;
                 moveLeft = true;
                 moveRight = false;
             }
             else
             {
                 moveForward = false;
                 moveBackward = false;
                 moveLeft = false;
                 moveRight = false;
             }*/
            if (moveForward == true)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if (moveLeft == true)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 5);
            }
            else if (moveBackward == true)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if (moveRight == true)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 5);
            }
            if (type == PieceType.bike)
            {
                moveForward = moveForward;
                moveBackward = moveBackward;
                moveRight = moveRight;
                moveLeft = moveLeft;
                if (gameObject.transform.position.x >= maxX)
                {
                    moveRight = false;
                    moveLeft = true;
                }
                if (gameObject.transform.position.z <= minZ)
                {
                    moveForward = false;
                    moveBackward = true;

                }
                if (gameObject.transform.position.x <= minX)
                {
                    moveLeft = false;
                    moveRight = true;

                }
                if (gameObject.transform.position.z >= maxZ)
                {
                    moveBackward = false;
                    moveForward = true;

                }
                if ((moveForward == false) && (moveBackward == false) && (moveLeft = false) && (moveRight == false))
                {
                    moveForward = true;
                    moveBackward = false;
                    moveLeft = false;
                    moveRight = false;
                }
            }
            if (type == PieceType.spider)
            {
                moveForward = moveForward;
                moveBackward = moveBackward;
                moveRight = moveRight;
                moveLeft = moveLeft;
                if ((gameObject.transform.position.x >= maxX) && (gameObject.transform.position.z >= maxZ))
                {
                    moveBackward = true;
                    moveLeft = true;
                    moveRight = false;
                    moveForward = false;
                }
                else if ((gameObject.transform.position.x >= maxX) && (gameObject.transform.position.z <= minZ))
                {
                    moveBackward = true;
                    moveLeft = false;
                    moveRight = true;
                    moveForward = false;
                }
                else if ((gameObject.transform.position.x <= minX) && (gameObject.transform.position.z <= minZ))
                {
                    moveBackward = false;
                    moveLeft = false;
                    moveRight = true;
                    moveForward = true;
                }
                else if ((gameObject.transform.position.x <= minX) && (gameObject.transform.position.z >= maxZ))
                {
                    moveBackward = false;
                    moveLeft = true;
                    moveRight = false;
                    moveForward = true;
                }
                if ((moveForward == false) && (moveBackward == false) && (moveLeft = false) && (moveRight == false))
                {
                    moveForward = true;
                    moveBackward = false;
                    moveLeft = false;
                    moveRight = true;
                }
            }
        }
    }

    public enum PieceType
    {
        bike,
        tank,
        spider
    }
}