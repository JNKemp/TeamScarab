using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourManager : MonoBehaviour
{
    //this bad boy here is a list that holds all the colours the player has unlocked. wild. Colours are added through the ChangeColourOnTrigger script :)
    public List<string> str_unlockedColours;
    private GameObject go_WhiteFade;
    private Image im_white;

    public bool bl_fadewhiteDone;
    private bool bl_fadeback;

    private float t = 0f;
    private float fl_duration = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        go_WhiteFade = GameObject.Find("WhiteFade");

        bl_fadewhiteDone = true;

    }


    //You can ignore this stuff. It's for fading the screen to white. Just here for safe keeping in case we need it later. Which we probably will when we go through levels.

    // Update is called once per frame
    void Update()
    {
        if (!bl_fadewhiteDone)
        {
            StartCoroutine(FadeWhite());
        }
        if (bl_fadeback)
        {
            StartCoroutine(FadeBack());
        }
            
    }

    IEnumerator FadeWhite()
    {
        
        im_white.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, t));
        if (t < 1)
        {
            t += Time.deltaTime / fl_duration;
        }
        else
        {
            yield return new WaitForSeconds(1);
            bl_fadewhiteDone = true;
            bl_fadeback = true;
            t = 0;
        }
        yield break;
        
    }

    IEnumerator FadeBack()
    {
        im_white.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
        if (t < 1)
        {
            t += Time.deltaTime / fl_duration;
        }
        else
        {
            bl_fadeback = false;
            t = 0;
        }
        yield break;
    }
}
