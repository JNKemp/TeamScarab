using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_Portal_Walkthrough : MonoBehaviour
{
    private Animator DoorAnim;
    public GameObject Door;
    public GameObject CameraPane;
    public GameObject CollisionPlane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoorAnim = Door.GetComponent<Animator>();
            DoorAnim.Play("DoorClose");
            CameraPane.SetActive(false);
            CollisionPlane.SetActive(false);
        }
    }
}
