using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_DoorOpen : MonoBehaviour
{
    private Animator DoorAnim;

    public GameObject collisionPlane;
    public GameObject cameraPlane;

    public GameObject Forest;
    public GameObject Beach;

    public string DoorColour;

    public static bool isDoorOpen;

    void Interact()
    {
        if(isDoorOpen == false)
        {
            DoorAnim = GetComponent<Animator>();
            DoorAnim.Play("DoorOpen");
            GetComponent<BoxCollider>().enabled = false;

            collisionPlane.SetActive(true);
            cameraPlane.SetActive(true);

            PortalTexture.ActiveDoor = DoorColour;
            isDoorOpen = true;
        }
    }
}
