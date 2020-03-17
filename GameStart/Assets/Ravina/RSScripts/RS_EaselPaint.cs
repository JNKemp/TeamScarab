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

    public GameObject ExitDoor;
    public GameObject ReturnZone;

    public Vector3 ReturnPos;

    private Animator an_easel;

    public GameObject CollectText;
    private float Delay;
    private bool TextActive;

    public enum colours
    {
        Blank,
        //MAIN
        Red,
        Yellow,
        Green,
        Blue,
        Purple,
        Brown,
        //OPTIONAL
        Orange,
        Pink,


    }
    public colours Colour1;
    public colours Colour2;

    private GameObject go_colourManager;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour1.ToString()) && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour2.ToString()))
        {
            if (ExitDoor)
            {
                ExitDoor.SetActive(true);
            }
        }
        if (Time.time >= Delay && TextActive == true)
        {
            CollectText.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        an_easel = GetComponent<Animator>();
        
        Part1.SetActive(false);
        Part2.SetActive(false);
        Part3.SetActive(false);
        PartCompl.SetActive(false);

        ReturnZone.SetActive(false);
        ExitDoor.GetComponent<BoxCollider>().enabled = false;

        ExitDoor.SetActive(false);
        CollectText.SetActive(false);
        go_colourManager = GameObject.Find("Colour Manager");
    }

    void Interact()
    {
        if (go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour1.ToString()) && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour2.ToString()))
        {
            an_easel.SetBool("bl_paint", true);
            ExitDoor.transform.position = ReturnPos;
            ExitDoor.GetComponent<BoxCollider>().enabled = true;
            ReturnZone.SetActive(true);
        } else
        {
            CollectText.SetActive(true);
            TextActive = true;
            Delay = Time.time + 5f;
        }
    }
}
