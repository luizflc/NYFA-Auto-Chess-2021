    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceSelector : MonoBehaviour
{
    public Button[] pieceButtons;
    public Sprite[] piecesPic;
    public GameObject[] pieces;
    public SpawnPiece[] spawners;
    public Text[] cornerPrices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Refresh();
        } 
    }

    public void Refresh()
    {
        int pieceNum;
        for(int i = 0; i < pieceButtons.Length; i++)
        {
            pieceNum = Random.Range(0, pieces.Length);
            pieceButtons[i].gameObject.SetActive(true);
            pieceButtons[i].GetComponent<Image>().sprite = piecesPic[pieceNum];
            spawners[i].currPiece = pieceNum;
            cornerPrices[i].text = "Corners: " + pieces[pieceNum].GetComponent<PlayablePiece>().shape.cost.ToString();
        }
    }

    public void HideStore()
    {
        for (int i = 0; i < pieceButtons.Length; i++)
        {
            pieceButtons[i].gameObject.SetActive(false);
        }
    }
    public void ShowStore()
    {
        for (int i = 0; i < pieceButtons.Length; i++)
        {
            pieceButtons[i].gameObject.SetActive(true);
        }
    }
}
