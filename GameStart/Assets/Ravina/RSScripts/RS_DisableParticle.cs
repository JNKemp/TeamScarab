using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_DisableParticle : MonoBehaviour
{
    public GameObject PartcileSystem;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PartcileSystem.SetActive(false);
        }
    }
}
