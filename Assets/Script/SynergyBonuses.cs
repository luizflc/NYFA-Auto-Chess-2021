using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynergyBonuses : MonoBehaviour
{
    int redCount;
    int yellowCount;
    int blueCount;
    int greenCount;
    int purpleCount;
    int cubeCount;
    int sphereCount;
    int pyramidCount;
    GameObject[] playerPieces;
    public static SynergyBonuses instance;
    public Text colorText;
    public Text shapeText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (redCount >= 2)
        {
            colorText.text = "Red";
            colorText.color = Color.red;
        }
        else if (blueCount >= 2)
        {
            colorText.text = "Blue";
            colorText.color = Color.blue;
        }
        else if (yellowCount >= 2)
        {
            colorText.text = "Yellow";
            colorText.color = Color.yellow;
        }
        else if (greenCount >= 2)
        {
            colorText.text = "Green";
            colorText.color = Color.green;
        }
        else if (purpleCount >= 2)
        {
            colorText.text = "Purple";
            colorText.color = new Color(7, 0, 1);
        }
        else
        {
            colorText.text = "None";
            colorText.color = Color.white;
        }
        if (cubeCount >= 3)
        {
            shapeText.text = "Cube";
        }
        else if (pyramidCount >= 3)
        {
            shapeText.text = "Pyramid";
        }
        else if (sphereCount >= 3)
        {
            shapeText.text = "Sphere";
        }
        else
        {
            shapeText.text = "None";
        }
    }

    public void UpdateSynergies()
    {
        redCount = 0;
        yellowCount = 0;
        blueCount = 0;
        greenCount = 0;
        purpleCount = 0;
        cubeCount = 0;
        sphereCount = 0;
        pyramidCount = 0;
        playerPieces = GameObject.FindGameObjectsWithTag("PlayerPiece");
        for(int i = 0; i < playerPieces.Length; i++)
        {
            if (playerPieces[i].GetComponent<PlayablePiece>().color.name == "Red"){
                redCount += 1;
            }
            else if (playerPieces[i].GetComponent<PlayablePiece>().color.name == "Yellow")
            {
                yellowCount += 1;
            }
            else if (playerPieces[i].GetComponent<PlayablePiece>().color.name == "Blue")
            {
                blueCount += 1;
            }
            else if (playerPieces[i].GetComponent<PlayablePiece>().color.name == "Green")
            {
                greenCount += 1;
            }
            else if (playerPieces[i].GetComponent<PlayablePiece>().color.name == "Purple")
            {
                purpleCount += 1;
            }

            if (playerPieces[i].GetComponent<PlayablePiece>().shape.name == "Cube")
            {
                cubeCount += 1;
            }
            else if (playerPieces[i].GetComponent<PlayablePiece>().shape.name == "Sphere")
            {
                sphereCount += 1;
            }
            else if (playerPieces[i].GetComponent<PlayablePiece>().shape.name == "Pyramid")
            {
                pyramidCount += 1;
            }
        }
        if(redCount >= 2)
        {
            BoostRed();
        }
        else if(blueCount >= 2)
        {
            BoostBlue();
        }
        else if(yellowCount >= 2)
        {
            BoostYellow();
        }
        else if(greenCount >= 2)
        {
            BoostGreen();
        }
        else if (purpleCount >= 2)
        {
            BoostPurple();
        }
        if(cubeCount >= 3)
        {
            BoostCube();
        }
        else if(pyramidCount >= 3)
        {
            BoostPyramid();
        }
        else if(sphereCount >= 3)
        {
            BoostSphere();
        }

    }

    public void BoostRed()
    {
        for(int i = 0; i<playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().health += 3;
        }
    }
    public void BoostBlue()
    {
        for(int i = 0; i<playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().damage += 5;
        }
    }
    public void BoostYellow ()
    {
        for (int i = 0; i < playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().speed += .02f;
        }
    }
    public void BoostPurple()
    {
        for (int i = 0; i < playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().speed -=.01f;
        }
    }
    public void BoostGreen()
    {
        for (int i = 0; i < playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().dmgRadius += 1;
        }
    }
    public void BoostSphere()
    {
        for (int i = 0; i < playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().health += 6;
        }
    }
    public void BoostCube()
    {
        for (int i = 0; i < playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().damage += 3;
        }
    }
    public void BoostPyramid()
    {
        for (int i = 0; i < playerPieces.Length; i++)
        {
            playerPieces[i].GetComponent<PlayablePiece>().damage += 1;
            playerPieces[i].GetComponent<PlayablePiece>().health += 1;
        }
    }

}
