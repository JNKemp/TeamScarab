using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_SoundReverbControl : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject objectToEnable;
   

    // Put the reverb zone in the variable above (in the editor)
    public void Start()
    {
        objectToEnable.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToEnable.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // If the trigger is exited, disable the "objectToEnable"
            objectToEnable.SetActive(false);
        }
    }

}