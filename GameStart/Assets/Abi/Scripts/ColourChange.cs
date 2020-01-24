using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    private Renderer rend;
    private bool ConditionMet;
    
    private GameObject go_ColourManager;
    [SerializeField]
    private bool UseCustomColor;

    [ColorUsage(true,true)]
    public Color customColour;

    public enum colours
    {
        Blank,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        
    }
    public colours DesiredColour;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        go_ColourManager = GameObject.Find("Colour Manager");

        rend = GetComponent<Renderer>(); //get the renderer from the gameobject
        rend.material.color = Color.white; //turn it white 
        ConditionMet = false; //set the condition met to false
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go_ColourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(DesiredColour.ToString()))
        {
            ConditionMet = true; //if the player has unlocked the desired colour, condition met becomes true
        }

        //if the condition is met change the colour of the object to its desired colour
        if (ConditionMet)
        {
            StartCoroutine(ChangeColour());

        }
        else 
        {
            rend.material.color = Color.white;
        }

        
    }


    IEnumerator ChangeColour()
    {
        

        if (!UseCustomColor)
        {
            

            if (DesiredColour == colours.Red)
            {
                rend.material.color = Color.red;
                yield return new WaitForSeconds(3f);
            }
            if (DesiredColour == colours.Orange)
            {
                rend.material.color = new Color(1, 0.8f, 0, 1);
            }
            if (DesiredColour == colours.Yellow)
            {
                rend.material.color = Color.yellow;
            }
            if (DesiredColour == colours.Green)
            {
                rend.material.color = Color.green;
            }
            if (DesiredColour == colours.Blue)
            {
                rend.material.color = Color.blue;
            }
            if (DesiredColour == colours.Indigo)
            {
                rend.material.color = new Color(0.6f, 0.25f, 0.85f, 1);
            }
        }
        else
        {
            rend.material.color = customColour;
        }
        yield break;
    }


    //Use this to make it change over time?
    //currentColour = rend.material.color;
    //rend.material.color = Color.Lerp(currentColour, Color.red, 3f);
}
