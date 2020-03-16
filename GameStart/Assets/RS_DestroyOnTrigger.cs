using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_DestroyOnTrigger : MonoBehaviour
{
    public GameObject activator;
    public GameObject asset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == activator)
        {
            asset.SetActive(false);
        }
    }
}
