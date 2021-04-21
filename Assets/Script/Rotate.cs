using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0.0f)
        {
            m_timer += 3.0f;
            transform.Rotate( 0, 0, 180f);
            print("Rotating"); 
        }
    } 

   /* public void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Rotate"))
        {
            transform.Rotate(0f, 0f, +180.0f);
            Destroy(col.gameObject);
            print("Rotating");
        }

        else if ((col.gameObject.tag == "NoRotate"))
        {
            transform.Rotate(0f, 0f, -180.0f);
            Destroy(col.gameObject);
            print("Rotating");
        }

    }

    void Update()
    {

        if (Input.GetKey("k"))
        {
           transform.Rotate (0f, 0f, +180.0f);
        }

    } */

}
