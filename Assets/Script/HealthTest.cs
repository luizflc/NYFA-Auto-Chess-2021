using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour
{
    //Author Jordan Barboza

    public float Damage; 

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetHealthBarValue(1);
    }

    // Update is called once per frame
    /*void Update()
    {

        if (Input.GetKey("k"))
        {
            HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() - 0.0025f);
        }

        if (Input.GetKey("h"))
        {
            HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() + 0.0025f);
        }
    } */

   /* void Update()
    {
        if (HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() == 0)
        {

        }
    }*/

    public void OnTriggerEnter(Collider col)
    {
        if ((gameObject.tag == "PlayerPiece" && col.gameObject.tag == "EnemyPiece"))
        {
            HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() - Damage);

        }

        else if ((gameObject.tag == "EnemyPiece" && col.gameObject.tag == "PlayerPiece"))
        {
            HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() - Damage);

        }
    }
}
