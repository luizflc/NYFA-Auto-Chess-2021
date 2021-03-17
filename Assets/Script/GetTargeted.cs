using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargeted : MonoBehaviour
{
    public bool canBeTargeted = false;
    public ClickToTarget targeter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget() {
        print("You'rrree clicking");
         if(targeter != null)
        {
            targeter.targetPos = transform.position;
        }
    }
}
