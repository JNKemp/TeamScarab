using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JK_Pickup : MonoBehaviour
{
    private string RaycastObject;
    private GameObject Object;

    private Vector3 pickupPos;
    private Vector3 oldPos;

    private bool isPlayerHolding;

    [SerializeField]
    private GameObject Player;

    private float RotSpeed = 40;

    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask) && isPlayerHolding == false)
            {
                RaycastObject = hit.collider.gameObject.name;
                Object = GameObject.Find(RaycastObject);
                if (Object.tag == "Pickup")
                {
                    Debug.Log("Hit pickup with raycast");
                    isPlayerHolding = true;
                    FirstPersonController.isPlayerHolding = true;
                    oldPos = Object.transform.position;
                    Object.GetComponent<Rigidbody>().isKinematic = true;
                    Object.GetComponent<BoxCollider>().enabled = false;
                }
                else
                {
                    Debug.Log("Did not hit pickup");
                }
            }
            else if (isPlayerHolding == true)
            {
                Object.transform.position = oldPos;
                isPlayerHolding = false;
                FirstPersonController.isPlayerHolding = false;
                Object.GetComponent<BoxCollider>().enabled = true;
            }
        }
        //RotateHeldObject();
        MoveHeldObject();
    }

    void RotateHeldObject()
    {
        if (isPlayerHolding == true)
        {
            Object.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * RotSpeed);
        }
    }
    void MoveHeldObject()
    {
        if (isPlayerHolding == true)
        {
            pickupPos = transform.position + transform.forward;
            Object.transform.position = pickupPos;
        }
    }
}
