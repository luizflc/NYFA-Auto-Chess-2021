using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayablePieceV2 : MonoBehaviour
{
    public int damage;
    public int health;
    public int cost;
    public bool goingForward;
    public bool sideStrafe;
    bool canMoveSideways = false;
    bool canMoveForwards = true;
    public bool canMove;
    public int maxX;
    public int maxZ;
    public int minX;
    public int minZ;
    public float speed;
    public GameObject myManagerObject;
    public GameManager myManager;
    public PauseMenu MyPause;

    // Start is called before the first frame update
    void Start()
    {
        myManagerObject = GameObject.Find("GameManager");
        myManager = myManagerObject.GetComponent<GameManager>();
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
        public void OnTriggerEnter(Collider col)
        {
        if ((gameObject.tag == "PlayerPiece" && col.gameObject.tag == "EnemyPiece"))
        {
            col.gameObject.GetComponent<PlayablePieceV2>().health -= damage;
        }
        else if ((gameObject.tag == "EnemyPiece" && col.gameObject.tag == "PlayerPiece"))
        {
            col.gameObject.GetComponent<PlayablePieceV2>().health -= damage;
        }
        else
        {
            return;
        }
        }
    }