using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
        if ((gameObject.tag == "PlayerPiece" && col.gameObject.tag == "Snapbox"))
        {
            HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() + 0.5f);

        }

    }
}
