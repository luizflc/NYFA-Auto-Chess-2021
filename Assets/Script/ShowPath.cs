using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPath : MonoBehaviour
{
    public GameObject path;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        print("Mousing Over");
        path.SetActive(true);
    }

    void OnMouseExit()
    {
        path.SetActive(false);
        print("leaving object");
    }
}
