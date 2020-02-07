using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTP : MonoBehaviour
{
    public CharacterController player;
    public Transform reciever;

    public bool isPlayerOverlapping = false;
    // Update is called once per frame
    void Update()
    {
        if (isPlayerOverlapping == true)
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0f)
            {
                float rotationDifference = Quaternion.Angle(transform.rotation, reciever.rotation);
                //rotationDifference += 180f;
                player.transform.Rotate(Vector3.up, rotationDifference);

                Vector3 positionOffset = Quaternion.Euler(0, rotationDifference, 0) * portalToPlayer;
                player.enabled = false;
                player.transform.position = reciever.position + positionOffset;
                player.enabled = true;
                isPlayerOverlapping = false;
            }
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            isPlayerOverlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerOverlapping = false;
        }
    }
}
