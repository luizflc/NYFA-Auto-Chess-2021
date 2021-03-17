using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRayCaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.gameObject.tag == "EnemyPiece")
                {
                    hit.collider.gameObject.GetComponent<GetTargeted>().SetTarget();
                }
                else
                {
                    print("You aren't hitin nothin");
                }
            }
        }
    }
}
