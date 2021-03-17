using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToTarget : MonoBehaviour
{
    public bool canTarget;
    public Vector3 targetPos = Vector3.zero;
    public bool canTele;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTarget == true)
        {
            if (targetPos != Vector3.zero)
            {
                if (canTele == true)
                {
                    transform.position = targetPos;
                }
            }
        }

    }
    
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EnemyPiece")
        {
            col.gameObject.GetComponent<GetTargeted>().canBeTargeted = true;
            col.gameObject.GetComponent<GetTargeted>().targeter = this;
            canTarget = true;
            canTele = true;
        }
    }


    public void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "EnemyPiece")
        {
            col.gameObject.GetComponent<GetTargeted>().canBeTargeted = false;
            col.gameObject.GetComponent<GetTargeted>().targeter = null;
            canTarget = false;
            canTele = false;
        }
    }

}
