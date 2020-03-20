using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_DoorOpen : MonoBehaviour
{
    private Animator DoorAnim;

    public GameObject collisionPlane;
    public GameObject cameraPlane;


    public string DoorColour;

    public static bool isDoorOpen;

    public colours Colour1;
    public colours Colour2;
    public colours Colour3;
    public colours Colour4;
    public colours Colour5;
    public colours Colour6;

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
    private GameObject go_colourManager;


    // Start is called before the first frame update
    void Start()
    {
        go_colourManager = GameObject.Find("Colour Manager");
    }

    void Interact()
    {
        if(isDoorOpen == false)
        {
            if (DoorColour != "Black")
            {
                DoorAnim = GetComponent<Animator>();
                DoorAnim.Play("DoorOpen");
                GetComponent<BoxCollider>().enabled = false;

                collisionPlane.SetActive(true);
                cameraPlane.SetActive(true);

                PortalTexture.ActiveDoor = DoorColour;
                isDoorOpen = true;
            }
            else if(DoorColour == "Black")
            {
                if (go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour1.ToString()) && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour2.ToString())
                    && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour3.ToString()) && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour4.ToString())
                    && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour5.ToString()) && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour6.ToString()))
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
    }
}
