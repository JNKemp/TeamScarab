using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_ControlsSwitchTab : MonoBehaviour
{
    private GameObject ControlImage;
    // Start is called before the first frame update
    void Start()
    {
        ControlImage = GameObject.Find("ControlsTabImage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activateTab()
    {
        ControlImage.SetActive(true);
    }
}
