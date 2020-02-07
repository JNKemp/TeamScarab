using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    [SerializeField]
    private Material gray_SB_Forest;
    [SerializeField]
    private Material colour_SB_Forest;

    [SerializeField]
    private Material gray_SB_Beach;
    [SerializeField]
    private Material colour_SB_Beach;

    [SerializeField]
    private Material gray_SB_Aqua;
    [SerializeField]
    private Material colour_SB_Aqua;

    private GameObject go_ColourManager;

    //List of locations the player can be to determine what skybox should be shown
    public enum location
    {
        Blank,
        Forest,
        Beach,
        Aquarium,
    }
    //[HideInInspector]
    public location player_location;
    public enum colours_forest
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
    public colours_forest ForestSkyboxColour;

    public enum colours_beach
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
    public colours_beach BeachSkyboxColour;

    public enum colours_aqua
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
    public colours_aqua AquariumSkyboxColour;

    // Start is called before the first frame update
    void Start()
    {
        go_ColourManager = GameObject.Find("Colour Manager"); //Finds the Colour Manager in the scene

    }

    // Update is called once per frame
    void Update()
    {

        if (player_location == location.Forest)
        {
            if (go_ColourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(ForestSkyboxColour.ToString())) //Checks the Colour Manager to see if the player has unlocked the needed colour
            {
                RenderSettings.skybox = colour_SB_Forest;
            }
            else
            {
                RenderSettings.skybox = gray_SB_Forest;
            }
        }

        if (player_location == location.Beach)
        {
            if (go_ColourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(BeachSkyboxColour.ToString())) //Checks the Colour Manager to see if the player has unlocked the needed colour
            {
                RenderSettings.skybox = colour_SB_Beach;
            }
            else
            {
                RenderSettings.skybox = gray_SB_Beach;
            }
        }

        if (player_location == location.Aquarium)
        {
            if (go_ColourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(AquariumSkyboxColour.ToString())) //Checks the Colour Manager to see if the player has unlocked the needed colour
            {
                RenderSettings.skybox = colour_SB_Aqua;
            }
            else
            {
                RenderSettings.skybox = gray_SB_Aqua;
            }
        }
    }
}
