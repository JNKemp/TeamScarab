using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_Return : MonoBehaviour
{
    private Animator DoorAnim;
    public GameObject Door;
    public GameObject CameraPane;
    public GameObject CollisionPlane;

    public GameObject ReturnCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoorAnim = Door.GetComponent<Animator>();
            DoorAnim.Play("DoorClose");
            CameraPane.SetActive(false);
            CollisionPlane.SetActive(false);
            ReturnCollider.SetActive(false);
        }
    }
}
