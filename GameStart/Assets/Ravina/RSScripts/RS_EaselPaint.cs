using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_EaselPaint : MonoBehaviour
{
    public GameObject Player;
    public GameObject Part1;
    public GameObject Part2;
    public GameObject Part3;
    public GameObject PartCompl;
    public GameObject Text;

    public GameObject ExitDoor;
    public GameObject ReturnZone;

    private Animator an_easel;

    // Start is called before the first frame update
    void Start()
    {
        an_easel = GetComponent<Animator>();
        
        Part1.SetActive(false);
        Part2.SetActive(false);
        Part3.SetActive(false);
        PartCompl.SetActive(false);
        Text.SetActive(false);

        ReturnZone.SetActive(false);

        ExitDoor.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown (KeyCode.E))
        {
            an_easel.SetBool("bl_paint", true);
            ExitDoor.transform.position = new Vector3(134.25f, 51.16f, 213.9f);
            ExitDoor.GetComponent<BoxCollider>().enabled = true;
            ReturnZone.SetActive(true);
            //Part1.SetActive(true);
            //Part2.SetActive(true);
            //Part3.SetActive(true);
            //PartCompl.SetActive(true);
        }
        
    }
}
