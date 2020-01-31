using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourManager : MonoBehaviour
{
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
        im_white = go_WhiteFade.GetComponent<Image>();
        im_white.color = new Color(1, 1, 1, 0);
        bl_fadewhiteDone = true;
        //str_unlockedColours.Add("Red");
        str_unlockedColours.Add("Blue");
        str_unlockedColours.Add("Orange");
    }

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
