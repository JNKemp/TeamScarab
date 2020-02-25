using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_DoorOpen : MonoBehaviour
{
    private Animator DoorAnim;
    public Animator DoorAnim2;

    void OpenDoor()
    {
        DoorAnim = GetComponent<Animator>();
        DoorAnim.Play("DoorOpen");
        DoorAnim2.Play("DoorOpen");
        GetComponent<BoxCollider>().enabled = false;
    }
}
