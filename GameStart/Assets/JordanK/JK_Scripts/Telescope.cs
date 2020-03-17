using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Telescope : MonoBehaviour
{
    public Camera PlayerCam;
    public Camera TeleCam;

    public GameObject go_colourmanager;

    private void Start()
    {
        TeleCam.enabled = false;
    }
    void Interact()
    {
        if (FirstPersonController.isPlayerHolding == false)
        {
            TeleCam.enabled = true;
            PlayerCam.enabled = false;
            FirstPersonController.isPlayerHolding = true;
            go_colourmanager.GetComponent<ColourManager>().str_unlockedColours.Add(gameObject.GetComponent<PickupColour>().UnlockedColour.ToString());
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            FirstPersonController.isPlayerHolding = false;
            TeleCam.enabled = false;
            PlayerCam.enabled = true;
        }
    }
}
