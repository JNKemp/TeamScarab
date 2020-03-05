using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    private AudioSource as_object;
    private GameObject player;
    private BoxCollider bx_collider;
    // Start is called before the first frame update
    void Start()
    {
        as_object = gameObject.GetComponent<AudioSource>();
        player = GameObject.Find("FPSController");
        bx_collider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            as_object.Play();
            Destroy(bx_collider);
        }
    }
}
