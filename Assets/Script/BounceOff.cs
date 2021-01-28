using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        print(col.name);
        if(col.gameObject.transform.parent.GetComponent<PlayablePiece>() == true) {
            PlayablePiece currPiece = col.gameObject.transform.parent.GetComponent<PlayablePiece>();
            currPiece.speed *= -1;
            /*currPiece.goingForward = !currPiece.goingForward;
            currPiece.sideStrafe = !currPiece.sideStrafe;*/
            print(col.name + "has bounced");
        }
        else
        {
            return;
        }
    }
}
