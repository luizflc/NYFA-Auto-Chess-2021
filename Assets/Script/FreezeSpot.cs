using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpot : MonoBehaviour
{
    public GameObject pickupEffect;

    private bool triggered;
    public float durationOfEffect = 3f;
    private MeshRenderer thisRenderer;
    private float timer;
    public float timeScaleValue = 1.0f;


    void Start()
    {
        thisRenderer = gameObject.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            timer--;
            if (timer <= 0f)
            {
                triggered = false;
                timer = 0f;
                thisRenderer.enabled = true;
                //Time.timeScale = 1.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerPiece"))
        {
            if (!triggered)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
                triggered = true;
                timer = durationOfEffect;
                thisRenderer.enabled = false;
               // Time.timeScale = 0f;

            }
        }

    }
}
