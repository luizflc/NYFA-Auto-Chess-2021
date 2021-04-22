using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Luke Sapir

public class DragScript : MonoBehaviour
{

    public bool inBattle = false;
    public bool dragging = false;
    public GameObject homeSpace;
    public GridSquareScript homeScript;
    public MeshRenderer homeRenderer;
    public PlayablePieceV2 thisPiece;
    float distance;
    public bool noGrab;
    void Start()
    {
        thisPiece = gameObject.GetComponent<PlayablePieceV2>();
    }
    private void OnMouseDown()
    {
        //if (!inBattle)
        // {
        if (noGrab)
        {
            return;
        }
        if(gameObject.tag == "PlayerPiece")
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
        }
            
      //  }
    }
    private void OnMouseUp()
    {
        // if (!inBattle)
        //  {
        if (noGrab)
        {
            return;
        }
      if(gameObject.tag == "PlayerPiece")
        {
            dragging = false;
            if (homeSpace != null)
            {

                transform.position = homeSpace.transform.position + new Vector3(0, 1, 0);
                ForcedEnter();

                if (homeScript.thisSpace == GridSquareScript.SpaceType.battlefield)
                {
                    thisPiece.canMove = true;
                    inBattle = true;
                }
                else
                {
                    thisPiece.canMove = false;
                    inBattle = false;
                }
                // }
            }
        }
           
    }
    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = myRay.GetPoint(distance);
            transform.position = new Vector3 (rayPoint.x, transform.position.y, rayPoint.z);
        }
        else
        {
            if (homeScript != null && homeScript.thisSpace == GridSquareScript.SpaceType.battlefield)
            {
                noGrab = true;
            }
            else
            {
                noGrab = false;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        MeshRenderer otherRenderer = other.GetComponent<MeshRenderer>();
        GridSquareScript otherScript = other.GetComponent<GridSquareScript>();
        if (other.tag == "Snapbox")
        {
        //    otherRenderer.material = otherScript.ordinaryMaterial;
        }
    }
    public void ForcedExit()
    {
        if(homeRenderer.material.name == homeScript.selectedMaterial.name)
        {
        //    homeRenderer.material = homeScript.ordinaryMaterial;
        }
        

    }
    public void ForcedEnter()
    {
        if(homeRenderer.material.name == homeScript.ordinaryMaterial.name)
        {
          //  homeRenderer.material = homeScript.selectedMaterial;
        }
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Snapbox")
        {
            if (homeSpace == null || other.name != homeSpace.name)
            {
                if (homeSpace != null)
                {

                   // homeRenderer.material = homeScript.ordinaryMaterial;
                }
                    GridSquareScript otherScript = other.GetComponent<GridSquareScript>();
                    homeSpace = other.gameObject;
                    homeScript = homeSpace.GetComponent<GridSquareScript>();
                    homeRenderer = homeSpace.GetComponent<MeshRenderer>();

                    if(homeScript.thisSpace == GridSquareScript.SpaceType.battlefield && thisPiece != null)
                    {
                        thisPiece.canMove = true;
                    }
                    else if(homeScript.thisSpace == GridSquareScript.SpaceType.bench && thisPiece != null)
                    {
                        thisPiece.canMove = false;
                    }
                    
            }

            homeScript.taken = true;
           
            //homeRenderer.material = homeScript.selectedMaterial;

        }
           
          
        }

    }

