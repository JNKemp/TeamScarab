using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_OnTriggerAnimate : MonoBehaviour
{
    private GameObject Boat;
    private Animator BoatAnim;

    private GameObject Player; 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Boat = this.gameObject;
        BoatAnim = Boat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            BoatAnim.Play("Play");

        }
    }
}
