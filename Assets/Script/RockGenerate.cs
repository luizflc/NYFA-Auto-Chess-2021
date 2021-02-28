using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerate : MonoBehaviour
{
    public GameObject theRock;
    public int xPos;
    public int zPos;
    public int objectSpawn;
    public int objectQuantity;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while(objectQuantity <8)
        {
            objectSpawn = Random.Range(1, 8);
            xPos = Random.Range(22, -3);
            zPos = Random.Range(4, -36);
           // if (objectSpawn == 1)
           
            Instantiate(theRock, new Vector3(xPos, 100, zPos), Quaternion.identity);
            
            yield return new WaitForSeconds(1f);
            objectQuantity += 1;

        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
