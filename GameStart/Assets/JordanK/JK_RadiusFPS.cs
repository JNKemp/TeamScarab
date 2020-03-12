using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JK_RadiusFPS : MonoBehaviour
{

    private bool PlayerInRange = false;

    public GameObject InteractionPrompt;

    private GameObject InteractionObject;

    private Vector3 pickupPos;
    private Vector3 oldPos;

    private GameObject go_colourmanager;

    private bool isPlayerHolding;

    private void Start()
    {
        InteractionPrompt.SetActive(false);
        go_colourmanager = GameObject.Find("Colour Manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable" || other.tag == "Pickup")
        {
            PlayerInRange = true;
            InteractionPrompt.SetActive(true);
            InteractionObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Interactable" || other.tag == "Pickup")
        {
            PlayerInRange = false;
            InteractionPrompt.SetActive(false);
            InteractionObject = null;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerInRange == true && InteractionObject != null && isPlayerHolding == false)
            {

                InteractionPrompt.SetActive(false);
                if (InteractionObject.tag == "Pickup")
                {
                    isPlayerHolding = true;
                    FirstPersonController.isPlayerHolding = true;
                    oldPos = InteractionObject.transform.position;
                    InteractionObject.GetComponent<Rigidbody>().isKinematic = true;
                    InteractionObject.GetComponent<BoxCollider>().enabled = false;
                }
                else
                {
                    InteractionObject.SendMessage("Interact");
                    InteractionObject = null;
                }
            }
            else if (isPlayerHolding == true)
            {
                InteractionObject.transform.position = oldPos;
                isPlayerHolding = false;
                FirstPersonController.isPlayerHolding = false;
                InteractionObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
        MoveHeldObject();
    }
    void MoveHeldObject()
    {
        if (isPlayerHolding == true)
        {
            pickupPos = transform.position + transform.forward;
            InteractionObject.transform.position = pickupPos;
            go_colourmanager.GetComponent<ColourManager>().str_unlockedColours.Add(InteractionObject.GetComponent<PickupColour>().UnlockedColour.ToString());
        }
    }
}
