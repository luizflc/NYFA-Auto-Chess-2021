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
    //public float defaultSpeed;

    void Start()
    {
        //thisRenderer = gameObject.GetComponent<MeshRenderer>();
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
                powerUp.SetActive(true);
                timer = 0f;
                //thisRenderer.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerPiece"))
        {
            if (!triggered)
            {
                triggered = true;
                powerUp.SetActive(false);
                timer = durationOfEffect;
                Destroy(gameObject);
                //thisRenderer.enabled = false;
            }
            
        }

    }
}
