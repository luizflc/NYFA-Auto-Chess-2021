using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceSlip : MonoBehaviour
{
    public GameObject pickupEffect;

    private bool triggered;
    public float durationOfEffect = 6f;
    private float timer;
    public GameObject iceBlock;
 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                triggered = false;
                timer = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerPiece") || other.CompareTag("EnemyPiece"))
        {
            if (!triggered)
            {
                Instantiate(pickupEffect, transform.position + Vector3.up, Quaternion.identity);
                triggered = true;
                timer = durationOfEffect;
                Destroy(gameObject);
            }

        }

    }
}
