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
    public bool canMoveSideways;
    public bool canMoveForwards;
    public bool canMove;
    public int maxX;
    public int maxZ;
    public int minX;
    public int minZ;
    public float speed;
    public GameObject myManagerObject;
    public GameManager myManager;
    public PauseMenu MyPause;
    //variables for timePU
    public float timer;
    public bool fastTriggered;
    public bool slowTriggered;
    public float durationOfEffect = 3f;

    public bool stopTriggered;


    // Start is called before the first frame update
    void Start()
    {
        myManagerObject = GameObject.Find("GameManager");
        myManager = myManagerObject.GetComponent<GameManager>();

        MyPause = GameObject.Find("PauseUI").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPause.isPaused)
        {
            return;
        }
        if (myManager.notStarted)
        {
            return;
        }
        if (fastTriggered)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                fastTriggered = false;
                timer = 0f;
                gameObject.GetComponent<PlayablePieceV2>().speed /= 2;
                gameObject.GetComponent<PlayablePieceV2>().damage /= 2;
            }
        }
        if (slowTriggered)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                slowTriggered = false;
                timer = 0f;
                gameObject.GetComponent<PlayablePieceV2>().speed *= 2;
                gameObject.GetComponent<PlayablePieceV2>().health /= 2;
            }
        }
        if (stopTriggered)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                stopTriggered = false;
                timer = 0f;
                gameObject.GetComponent<PlayablePieceV2>().speed /= 3;
            }
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
    public void OnTriggerEnter(Collider col)
    {
        if ((gameObject.tag == "PlayerPiece" && col.gameObject.tag == "EnemyPiece"))
        {
            col.gameObject.GetComponent<PlayablePieceV2>().health -= damage;
            if (col != null && col.gameObject.GetComponent<PlayablePieceV2>().damage == 0)
            {
                col.gameObject.GetComponent<PlayablePieceV2>().health -= 1;
            }
            //this if statement is to check if the opposing piece is a bike, in the case of bikes hitting each other since their damage is both 0.  

        }
        else if ((gameObject.tag == "EnemyPiece" && col.gameObject.tag == "PlayerPiece"))
        {

            col.gameObject.GetComponent<PlayablePieceV2>().health -= damage;
            if (col != null && col.gameObject.GetComponent<PlayablePieceV2>().damage == 0)
            {
                col.gameObject.GetComponent<PlayablePieceV2>().health -= 1;
            }
        }
        //used for time power up
        else if (col.gameObject.tag == "timePU" && gameObject.tag == "PlayerPiece")
        {
            if (!fastTriggered)
            {
                fastTriggered = true;
                gameObject.GetComponent<PlayablePieceV2>().speed *= 2;
                gameObject.GetComponent<PlayablePieceV2>().damage *= 2;

                timer = durationOfEffect;
            }
        }
        else if (col.gameObject.tag == "slowPU" && gameObject.tag == "PlayerPiece")
        {
            if (!slowTriggered)
            {
                slowTriggered = true;
                gameObject.GetComponent<PlayablePieceV2>().speed /= 2;
                gameObject.GetComponent<PlayablePieceV2>().health *= 2;

                timer = durationOfEffect;
            }
        }
        //used in icelevel
        else if (col.gameObject.tag == "iceTile" && gameObject.tag == "PlayerPiece" || gameObject.tag == "EnemeyPiece")
        {
            stopTriggered = true;
            gameObject.GetComponent<PlayablePieceV2>().speed *= 3;
        }
        else
        {
            return;
        }
        }
}