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

    [ColorUsageAttribute(true, true)]
    [SerializeField]
    private Color fogForest;

    [ColorUsageAttribute(true, true)]
    [SerializeField]
    private Color fogBeach;

    [ColorUsageAttribute(true, true)]
    [SerializeField]
    private Color fogAquarium;

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
    [HideInInspector]
    public int in_currentLevel;
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
    public colours ForestSkyboxColour;

    
    public colours BeachSkyboxColour;

   
    public colours AquariumSkyboxColour;

    // Start is called before the first frame update
    void Start()
    {
        go_ColourManager = GameObject.Find("Colour Manager"); //Finds the Colour Manager in the scene
        RenderSettings.fog = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (player_location == location.Forest)
        {
            if (go_ColourManager.GetComponent<ColourManager>().str_unlockedColours.Contains(ForestSkyboxColour.ToString())) //Checks the Colour Manager to see if the player has unlocked the needed colour
            {
                RenderSettings.skybox = colour_SB_Forest;
                RenderSettings.fog = true;
                RenderSettings.fogColor = fogForest;
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
                RenderSettings.fog = true;
                RenderSettings.fogColor = fogBeach;
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
                RenderSettings.fog = true;
                RenderSettings.fogColor = fogAquarium;
            }
            else
            {
                RenderSettings.skybox = gray_SB_Aqua;
            }
        }

        if (in_currentLevel == 1)
        {
            player_location = location.Forest;
        }
        if (in_currentLevel == 2)
        {
            player_location = location.Beach;
        }
        if (in_currentLevel == 3)
        {
            player_location = location.Aquarium;
        }
    }
}
