using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquareScript : MonoBehaviour
{
    //Author: Luke Sapir

    public bool taken;
    public bool altered;
    public bool snapEnabled;
    public Material selectedMaterial;
    public Material ordinaryMaterial;
    public MeshRenderer thisRenderer;
    public SpaceType thisSpace;
   
    public GameObject myColumnObject;

    void Start()
    {
        if (thisSpace == SpaceType.battlefield)
        {
            myColumnObject = transform.parent.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(myColumnObject != null)
        {
            gameObject.tag = myColumnObject.tag;
        }
    }
    public enum SpaceType
    {
        battlefield,
        bench
    }
}
    

