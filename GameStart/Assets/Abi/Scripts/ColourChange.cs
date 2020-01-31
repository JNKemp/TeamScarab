using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [SerializeField]
    private bool ChangeMaterial;

    private Material mat_stored;
    private Material mat_blank;
    private bool bl_matChanged;
    private float t = 0f;
    private float fl_duration = 3f;

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
    public colours DesiredColour;


    // Start is called before the first frame update
    void Start()
    {
        go_ColourManager = GameObject.Find("Colour Manager");
        
        
        rend = GetComponent<Renderer>(); //get the renderer from the gameobject
        if (ChangeMaterial)
        {
            mat_stored = rend.material;
            mat_blank = new Material(Shader.Find("Standard"));
            mat_blank.color = Color.white;
        }
        Debug.Log(mat_stored);
        rend.material.color = Color.white; //turn it white 
        ConditionMet = false; //set the condition met to false
        bl_matChanged = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (go_ColourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(DesiredColour.ToString()))
        {
            ConditionMet = true; //if the player has unlocked the desired colour, condition met becomes true
        }

        if (ChangeMaterial)
        {
            if (ConditionMet)
            {
                rend.material = mat_stored; 
            }
            else
            {
                rend.material = mat_blank;
            }
        }
        else
        {
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
            if (DesiredColour == colours.Purple)
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

    IEnumerator ChangeMaterialOverTime()
    {
        
        yield break;
    }

    //Use this to make it change over time?
    //currentColour = rend.material.color;
    //rend.material.color = Color.Lerp(currentColour, Color.red, 3f);
}
