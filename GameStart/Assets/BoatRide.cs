using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BoatRide : MonoBehaviour
{
    public GameObject Player;

    public Camera PlayerCam;
    public Camera BoatCam;

    private void Start()
    {
        BoatCam.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FirstPersonController.isPlayerHolding = true;
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = new Vector3(-273.5f, 58.9f, 1449.5f);
            other.gameObject.GetComponent<CharacterController>().enabled = true;
            PlayerCam.enabled = true;
            BoatCam.enabled = true;
        }
    }
    void BoatEnd()
    {
        BoatCam.enabled = false;
        PlayerCam.enabled = true;
        FirstPersonController.isPlayerHolding = false;       
    }
}
