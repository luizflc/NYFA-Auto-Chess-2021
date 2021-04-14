using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float m_timer = 3.0f;

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
            transform.Rotate( 0, 180f, 0);
        }
    }
}
