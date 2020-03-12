using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_DoorOpen : MonoBehaviour
{
    private Animator DoorAnim;

    public GameObject collisionPlane;
    public GameObject cameraPlane;

    void Interact()
    {
        DoorAnim = GetComponent<Animator>();
        DoorAnim.Play("DoorOpen");
        GetComponent<BoxCollider>().enabled = false;

        collisionPlane.SetActive(true);
        cameraPlane.SetActive(true);
    }
}
