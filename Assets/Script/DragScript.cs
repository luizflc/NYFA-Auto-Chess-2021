using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{

    public bool inBattle = false;
    public bool dragging = false;
    float distance;

    void Start()
    {

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
    }
    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = myRay.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
