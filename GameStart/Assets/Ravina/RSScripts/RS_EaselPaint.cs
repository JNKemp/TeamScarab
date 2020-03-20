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

    public GameObject ExitDoor;
    public GameObject ReturnZone;

    public Vector3 ReturnPos;

    private Animator an_easel;

    public enum colours
    {
        Blank,
        //MAIN
        Red,
        Yellow,
        Green,
        Blue,
        Purple,
        Brown,
        //OPTIONAL
        Orange,
        Pink,


    }

    void Start()
    {
        an_easel = GetComponent<Animator>();
        
        Part1.SetActive(false);
        Part2.SetActive(false);
        Part3.SetActive(false);
        PartCompl.SetActive(false);

        ReturnZone.SetActive(false);
        ExitDoor.GetComponent<BoxCollider>().enabled = false;

        ExitDoor.SetActive(false);
    }

    void Interact()
    {
        an_easel.SetBool("bl_paint", true);
        ExitDoor.transform.position = ReturnPos;
        ExitDoor.GetComponent<BoxCollider>().enabled = true;
        ReturnZone.SetActive(true);
        ExitDoor.SetActive(true);
    }
}
