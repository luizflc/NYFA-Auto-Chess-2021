using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlowPU : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public GameObject[] spawnLocations;

    public float timer = 10f;

    // Start is called before the first frame update

    void Awake()
    {
        checkSpawns();
    }
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("slowPU"))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Respawn();
                timer = 10f;
            }
        }

    }
    public void Respawn()
    {
        int spawn = Random.Range(0, spawnLocations.Length);
        Instantiate(spawnObjects[0], spawnLocations[spawn].transform.position, Quaternion.identity);
    }
    public void checkSpawns()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPointSP");
    }
}
