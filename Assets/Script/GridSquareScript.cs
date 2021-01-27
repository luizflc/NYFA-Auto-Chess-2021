using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquareScript : MonoBehaviour
{
    //Author: Luke Sapir

    public bool taken;
    public Material selectedMaterial;
    public Material ordinaryMaterial;
    public SpaceType thisSpace;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum SpaceType
    {
        battlefield,
        bench
    }
}
