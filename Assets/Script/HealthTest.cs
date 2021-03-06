using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour
{
    //Author Jordan Barboza



    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey("k"))
        {
            HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() - 0.005f);
        }

        if (Input.GetKey("h"))
        {
            HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() + 0.005f);
        }
    }
}
