using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperUIScript : MonoBehaviour
{
    public ColorStats color;
    public ShapeStats shape;
    public GameObject HelperParent;
    public GameObject HelperObject;
    public Image HelperImage;
    public Text helperText;
    void Start()
    {
        HelperParent = GameObject.FindGameObjectWithTag("HelperUI");
        HelperObject = GameObject.FindGameObjectWithTag("HelperText");
        HelperImage = HelperParent.GetComponent<Image>();
        helperText = HelperObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        HelperImage.enabled = true;
        helperText.enabled = true;
        helperText.text = "HP: " + shape.health + "\n SPD: " + color.speed + "\n ATK: " + shape.damage + "\n RANGE: " + color.dmgRadius + "\n STARTING MOVE: " + color.direction;
    }
    private void OnMouseExit()
    {
        HelperImage.enabled = false;
        helperText.text = "";
        helperText.enabled = false;
        
    }
}
