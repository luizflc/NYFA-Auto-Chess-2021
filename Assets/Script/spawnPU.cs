﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPU : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public GameObject[] spawnLocations;
    // Start is called before the first frame update

    void Awake()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    void Start()
    {
        int spawn = Random.Range(0, spawnLocations.Length);
        Instantiate(spawnObjects[0], spawnLocations[spawn].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
