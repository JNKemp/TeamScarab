using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupColour : MonoBehaviour
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
    public colours UnlockedColour;
}
