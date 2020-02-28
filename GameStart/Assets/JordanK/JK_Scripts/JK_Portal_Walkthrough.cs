﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_Portal_Walkthrough : MonoBehaviour
{
    private Animator DoorAnim;
    public GameObject Door;
    public GameObject CameraPane;
    public GameObject CollisionPlane;

    public GameObject ReturnCollider;


    private void Start()
    {
        ReturnCollider.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "NewZone")
        {
            DoorAnim = Door.GetComponent<Animator>();
            DoorAnim.Play("DoorClose");
            CameraPane.SetActive(false);
            CollisionPlane.SetActive(false);
            ReturnCollider.SetActive(true);
            CameraFollow.doorActive = 2;

        }
        else if (other.tag == "Player" && gameObject.tag == "Return")
        {
            DoorAnim = Door.GetComponent<Animator>();
            DoorAnim.Play("DoorClose");
            CameraPane.SetActive(false);
            CollisionPlane.SetActive(false);
            gameObject.SetActive(false);
            JK_DoorOpen.isDoorOpen = false;
        }
    }
}