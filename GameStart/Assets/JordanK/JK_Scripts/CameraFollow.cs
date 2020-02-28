using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerCamera;

    public static int doorActive = 0;

    private Transform activePortal;
    private Transform activeOtherPortal;

    public Transform portal;
    public Transform otherPortal;

    public Transform portal2;
    public Transform otherPortal2;


    // Update is called once per frame
    void Update()
    {
        if (doorActive == 1)
        {
            activeOtherPortal = otherPortal;
            activePortal = portal;
        }
        else if (doorActive == 2)
        {
            activeOtherPortal = otherPortal2;
            activePortal = portal2;
        }

        if (doorActive != 0)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - activeOtherPortal.position;
            transform.position = activePortal.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(activePortal.rotation, activeOtherPortal.rotation);

            Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}
