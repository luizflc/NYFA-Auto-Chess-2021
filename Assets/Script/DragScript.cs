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
    public PlayablePiece thisPiece;
    float distance;

    void Start()
    {
        thisPiece = gameObject.GetComponent<PlayablePiece>();
    }
    private void OnMouseDown()
    {
        if (!inBattle)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
        }
    }
    private void OnMouseUp()
    {
        dragging = false;
        if (homeSpace != null)
        {
            transform.position = homeSpace.transform.position + new Vector3 (0,1,0);

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
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = myRay.GetPoint(distance);
            transform.position = new Vector3 (rayPoint.x, 1, rayPoint.z + (-.05f * rayPoint.z));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Snapbox")
        {
            if (homeSpace == null || other.name != homeSpace.name)
            {
                GridSquareScript otherScript = other.GetComponent<GridSquareScript>();

                if (otherScript.taken == false)
                {
                    if (homeSpace != null)
                    {
                        homeScript.taken = false;
                        homeRenderer.material = homeScript.ordinaryMaterial;
                    }
                    homeSpace = other.gameObject;
                    homeScript = homeSpace.GetComponent<GridSquareScript>();
                    homeRenderer = homeSpace.GetComponent<MeshRenderer>();
                    if(homeScript.thisSpace == GridSquareScript.SpaceType.battlefield)
                    {
                        thisPiece.canMove = true;
                    }
                    else if(homeScript.thisSpace == GridSquareScript.SpaceType.bench)
                    {
                        thisPiece.canMove = false;
                    }
                    homeScript.taken = true;
                    homeRenderer.material = homeScript.selectedMaterial;
                }
            }
            else
            {
                return;
            }
        }
    }
}
