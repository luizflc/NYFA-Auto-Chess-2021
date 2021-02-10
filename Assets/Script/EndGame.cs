using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Jordan Barboza



public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    // Ends game when escape is pressed

    // Update is called once per frame
    void Update () {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}

}

