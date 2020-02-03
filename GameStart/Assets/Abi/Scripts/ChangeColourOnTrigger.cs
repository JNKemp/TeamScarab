using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourOnTrigger : MonoBehaviour
{

    private GameObject go_colourManager;
    //Set int the IDE whether or not the object should be destroyed after the colour is unlocked
    [SerializeField]
    private bool DestroyObjectAfter;

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
    [SerializeField]
    private colours ColourToUnlock;
    private string str_colourtounlock;
    // Start is called before the first frame update
    void Start()
    {
        go_colourManager = GameObject.Find("Colour Manager"); //Finds the object called Colour Manager
        Debug.Assert(go_colourManager, "There is no Colour Manager in the scene! That's wild please put one in our whole game revolves around colour! :,)");
        str_colourtounlock = ColourToUnlock.ToString();//Converts the chosen colour to a string
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ColourToUnlock != colours.Blank)
        {
            go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Add(str_colourtounlock); //Adds the chosen colour to the list of unlocked colours in the Colour Manager.
        }
        else
        {
            Debug.LogAssertion("You need to assign a colour to unlock! It is currently set as Blank! That's not what you want! There's a dropdown list of all colours on the object this script is on. :)");
        }
        
        if (DestroyObjectAfter)
        {
            Destroy(gameObject); //Destroys the gameobject if it has been set to
        }
        
    }
}
