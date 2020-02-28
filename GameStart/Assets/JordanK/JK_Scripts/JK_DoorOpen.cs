using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_DoorOpen : MonoBehaviour
{
    private Animator DoorAnim;

    public static bool isDoorOpen;

    void OpenDoor()
    {
        if (isDoorOpen == false)
        {
            DoorAnim = GetComponent<Animator>();
            DoorAnim.Play("DoorOpen");
            GetComponent<BoxCollider>().enabled = false;
            if(gameObject.tag == "BlueDoor")
            {
                CameraFollow.doorActive = 1;
            }
            else if(gameObject.tag == "YellowDoor")
            {

            }
            else if(gameObject.tag == "GreenDoor")
            {

            }
            isDoorOpen = true;
        }
    }
}
