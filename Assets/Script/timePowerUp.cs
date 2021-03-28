using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    private bool triggered;
    public float durationOfEffect = 6f;
    //private MeshRenderer thisRenderer;
    private float timer;
    public GameObject powerUp;
    //GameObject respawner;
    //GameObject checking;
    //public float defaultSpeed;

    void Start()
    {
        //thisRenderer = gameObject.GetComponent<MeshRenderer>();
        //particle = GetComponent<ParticleSystem>();
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
                //thisRenderer.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerPiece"))
        {
            if (!triggered)
            {
                Instantiate(pickupEffect, transform.position + Vector3.up, Quaternion.identity);
                triggered = true;
                timer = durationOfEffect;
                Destroy(gameObject);
                //thisRenderer.enabled = false;
            }
            
        }

    }
}
