using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_ColourTest : MonoBehaviour
{
    private float BlendValue = 0;
    private float BlendChange = 0.01f;
    void Update()
    {
        if(BlendValue > 1 || BlendValue < 0)
        {
            BlendChange *= -1;
        }
        BlendValue += BlendChange;
        gameObject.GetComponent<Renderer>().material.SetFloat("_Blend", BlendValue);
    }
}
