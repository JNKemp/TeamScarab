using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_SettingsChangeTab : MonoBehaviour
{
    private GameObject ControlsImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlsImage = GameObject.Find("ControlsTabImage");
    }

    public void switchtabs()
    {
        ControlsImage.SetActive(false);
    }
}
