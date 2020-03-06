using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_OnTriggerActivate : MonoBehaviour
{
    public GameObject asset;
    public GameObject activator;
    // Start is called before the first frame update
    void Start()
    {
        asset.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == activator)
        {
            asset.SetActive(true);
        }
    } 
}
