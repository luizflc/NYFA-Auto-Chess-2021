using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float timeScaleValue = 1.0f;
    private bool triggered;
    public float durationOfEffect = 3f;
    private MeshRenderer thisRenderer;
    private float timer;
    public PlayablePiece playerPiece;
    //public float defaultSpeed;

    void Start()
    {
        thisRenderer = gameObject.GetComponent<MeshRenderer>();
        //playerPiece = gameObject.GetComponent<PlayablePiece>();
        //playerPiece.speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            timer -= (Time.deltaTime / Time.timeScale);
            if (timer <= 0f)
            {
                triggered = false;
                timer = 0f;
                thisRenderer.enabled = true;
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02f;
                //playerPiece.speed = defaultSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerPiece"))
        {
            if (!triggered)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
                triggered = true;
                timer = durationOfEffect;
                thisRenderer.enabled = false;
                Time.timeScale = 0.5f * timeScaleValue;
                //playerPiece.speed = defaultSpeed * 2;

            }
        }

    }
}
