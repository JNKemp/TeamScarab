using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RS_AppleFall : MonoBehaviour

    
{
    public GameObject player;
    public GameObject Apple;
    private Rigidbody appleRigid;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        appleRigid = Apple.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            appleRigid.isKinematic = false;
        }
    }
}
