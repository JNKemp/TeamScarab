using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAppear : MonoBehaviour
{
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

    [SerializeField]
    private GameObject UnlockableDoor;

    // Start is called before the first frame update
    void Start()
    {
        UnlockableDoor.SetActive(false);
        go_colourManager = GameObject.Find("Colour Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour1.ToString()) && go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(Colour2.ToString()))
        {
            if (UnlockableDoor)
            {
                UnlockableDoor.SetActive(true);
            }
        }
    }
}
