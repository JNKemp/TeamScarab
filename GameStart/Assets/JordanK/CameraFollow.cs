using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerCamera;

    private Transform portal;
    private Transform otherPortal;

    public Transform GreenA;
    public Transform GreenB;
    public Transform YellowA;
    public Transform YellowB;

    // Start is called before the first frame update
    public void Update()
    {
        if(PortalTexture.ActiveDoor == "Green")
        {
            portal = GreenA;
            otherPortal = GreenB;
        }
        else if(PortalTexture.ActiveDoor == "Yellow")
        {
            portal = YellowA;
            otherPortal = YellowB;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(portal != null && otherPortal != null)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            transform.position = portal.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

            Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}
