using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_RS_SilhouetteFade : MonoBehaviour
{
    public GameObject joints;
    private Animator jointsanim;
    public GameObject surface;
    private Animator surfaceanim;
    private GameObject Silhoutte;
    private Animator SilhoutteAnim;

    Color transparent = new Color(0f, 0f, 0f, 0f);

    public bool isThisFading = false;

    // Start is called before the first frame update
    void Start()
    {
        /*Silhoutte = this.gameObject;
        SilhoutteAnim = Silhoutte.GetComponent<Animator>();
        SilhoutteAnim.Play("Throw");

        jointsanim = joints.GetComponent<Animator>();
        surfaceanim = surface.GetComponent<Animator>();

        jointsanim.Play("FadeJoints");
        surfaceanim.Play("FadeSurface");
        */



        //if (SilhoutteAnim.GetCurrentAnimatorStateInfo(0).IsName("Throw"))

        {
            // var jointsRenderer = joints.GetComponent<Renderer>();
            // jointsRenderer.material.SetColor("_Color", transparent);

            //var surfaceRenderer = surface.GetComponent<Renderer>();
            // surfaceRenderer.material.SetColor("_Color", transparent);
            // Debug.Log( "Yes, Im invisible");
        }






    }

    // Update is called once per frame
    void Update()
    {
        if (isThisFading == true)
        {

        }
    }

    public void fadeOut()
    {



    }
}
