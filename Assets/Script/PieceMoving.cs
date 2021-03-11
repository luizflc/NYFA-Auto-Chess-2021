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
    public float timerStart;
    float timer;
    public PieceType type;
    bool moveForward;
    bool moveBackward;
    bool moveRight;
    bool moveLeft;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerStart;   
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
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
        if(type == PieceType.bike)
        {
            if (gameObject.transform.position.x <= minX)
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
