﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_EaselPaint : MonoBehaviour
{
    public GameObject Player;
    public GameObject Part1;
    public GameObject Part2;
    public GameObject Part3;
    public GameObject PartCompl;

    // Start is called before the first frame update
    void Start()
    {
        //Part1.SetActive(false);
        //Part2.SetActive(false);
        //Part3.SetActive(false);
        //PartCompl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
            if (Input.GetKeyDown (KeyCode.P))
            {
                Part1.SetActive(true);
                Part2.SetActive(true);
                Part3.SetActive(true);
                PartCompl.SetActive(true);
            }
        
    }
}
