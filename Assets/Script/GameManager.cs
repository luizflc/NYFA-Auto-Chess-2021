using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PieceSelector storeFront;
    // Start is called before the first frame update
    void Start()
    {
        storeFront.Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
