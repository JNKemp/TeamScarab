using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainenabledisabe : MonoBehaviour
{
    public GameObject Terrain1;
    public GameObject Terrain2;
    // Start is called before the first frame update
    void Start()
    {
        Terrain1.SetActive(true);
        Terrain2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Terrain1.SetActive(false);
            Terrain2.SetActive(true);
        }
    }
}
