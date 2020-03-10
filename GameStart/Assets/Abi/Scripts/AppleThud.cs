using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleThud : MonoBehaviour
{
    private AudioSource apple;
    // Start is called before the first frame update
    void Start()
    {
        apple = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        apple.Play();
        Debug.Log("working");
    }
}
