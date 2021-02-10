using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.transform./*parent.*/tag != gameObject.transform.parent.tag)
        {
            PlayablePiece currPiece = col.gameObject/*.transform.parent*/.GetComponent<PlayablePiece>();
            currPiece.health -= gameObject.transform.parent.GetComponent<PlayablePiece>().damage;
        }
    }
}
