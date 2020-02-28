using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    

    private Texture tex_stored;
    private Material mat_blank;


    private float BlendValue = 1;
    private float BlendChange = 0.01f;

    private Renderer rend;
    private bool ConditionMet;
    
    private GameObject go_ColourManager;

    [SerializeField]
    private bool UnlockAudio;
    [SerializeField]
    private bool IsWater;
    private Animator an_water;


    private AudioSource as_object;
    private bool bl_audioPlaying;


    //List of unlockable colours. Choose one of these in the IDE and once it has been unlocked in the Colour Manager, the object will change colour.
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
        go_ColourManager = GameObject.Find("Colour Manager"); //Finds the Colour Manager in the scene
        
        
        rend = GetComponent<Renderer>(); //get the renderer from the gameobject
        
        if (IsWater)
        {
            an_water = GetComponent<Animator>();
        }
        else
        {
            tex_stored = rend.material.mainTexture; //Stores the texture of the object
            mat_blank = new Material(Shader.Find("Custom/Texture Blend")); //Sets the shader to a custom shader that allows the material to fade between two textures
            mat_blank.color = Color.gray; //sets the material to white, so its all dull until the world is lit up
        }
        
        
        ConditionMet = false; //set the condition met to false

        if (UnlockAudio)
        {
            Debug.Assert(!as_object, "You have checked for this object to unlock audio but there is no Audio Source on this GameObject!");
            as_object = GetComponent<AudioSource>(); //gets the audio source on the gameobject
            as_object.playOnAwake = false; //makes it not play instantly in case it was accidently left checked
            bl_audioPlaying = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (go_ColourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(DesiredColour.ToString())) //Checks the Colour Manager to see if the player has unlocked the needed colour
        {
            ConditionMet = true; //if the player has unlocked the desired colour, condition met becomes true
        }
        else if (DesiredColour == colours.Blank)
        {
            Debug.LogAssertion("You haven't picked a colour for this object so it will never be unlocked! this object will be grey forever :( You should set a colour.");
        }

        if (ConditionMet) //has the player unlocked the colour?
        {
            if (IsWater)
            {
                //rend.material = matWater;
                an_water.SetBool("ConditionMet", true);
            }
            else
            {
                rend.material.mainTexture = tex_stored; //set the texture we are fading to back to what it originally was
                if (BlendValue <= 0) //if its below 0 STOP! otherwise it goes too far and the apple turns black or blue. not fun.
                {
                    BlendValue = 0;
                    BlendChange = 0;
                }
                else
                {
                    BlendValue -= BlendChange; //gradually decrease the blend value until its 0
                }

                gameObject.GetComponent<Renderer>().material.SetFloat("_Blend", BlendValue); //actually set the blend value
            }
            

            if (UnlockAudio && !bl_audioPlaying) //check if the object should be playing audio and it isn't already
            {
                bl_audioPlaying = true; //set a flag that the audio is playing so it doesnt play every frame
                as_object.Play(); //play the audio
            }

        }
        else
        {
            if (!IsWater)
            {
                rend.material = mat_blank; //if the player hasn't unlocked the colour the material is white. so sad.
            }
            
        }
    }
}
