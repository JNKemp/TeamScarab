using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public List<string> str_unlockedColours;
    
    public enum UnlockedColours
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo
    }
    // Start is called before the first frame update
    void Start()
    {
        str_unlockedColours.Add("Red");
        str_unlockedColours.Add("Blue");
        str_unlockedColours.Add("Orange");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
