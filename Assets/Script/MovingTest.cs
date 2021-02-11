using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingTest : MonoBehaviour
{
    public GameObject[] waypoint;
    int current = 0;
    float rotSpeed;
    public float speed;
    float wPradius = 1;

    private void Update()
    {
        if(Vector3.Distance(waypoint[current].transform.position, transform.position) < wPradius)
        {
            current++;
            if(current >= waypoint.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoint[current].transform.position, Time.deltaTime * speed);
    }

}
