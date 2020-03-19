using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    private GameObject Player;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            controller.m_GravityMultiplier = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            controller.m_GravityMultiplier = 2;
        }
    }
}
