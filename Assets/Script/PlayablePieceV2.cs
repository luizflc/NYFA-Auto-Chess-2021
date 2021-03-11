using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayablePieceV2 : MonoBehaviour
{
    public int damage;
    public int health;
    public int cost;

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
        if ((gameObject.tag == "PlayerPiece" && col.gameObject.tag == "EnemyPiece"))
        {
            col.gameObject.GetComponent<PlayablePieceV2>().health -= damage;
        }
        else if ((gameObject.tag == "EnemyPiece" && col.gameObject.tag == "PlayerPiece"))
        {
            col.gameObject.GetComponent<PlayablePieceV2>().health -= damage;
        }
    }
}
