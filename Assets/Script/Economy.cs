﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public Text p1Text;
    public int p1Corners;
    public int p2Corners;
    public static Economy instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        p1Corners = 4;
        p2Corners = 4;
    }

    // Update is called once per frame
    void Update()
    {
        p1Text.text ="Corners: " + p1Corners.ToString();
    }

    public void AddCorners(int corner)
    {
        p1Corners += corner;
    }

    public void SubtractCorners(int corner)
    {
        p1Corners -= corner;
    }
}
