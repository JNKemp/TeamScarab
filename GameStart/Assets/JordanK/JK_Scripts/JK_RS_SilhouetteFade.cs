using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_RS_SilhouetteFade : MonoBehaviour
{
    public GameObject joints;
    private Animator jointsanim;

    public GameObject surface;
    private Animator surfaceanim;

    private AudioSource VoiceLine;

    private Animator SilhoutteAnim;

    private bool hasAnimPlayed = false;
    void Start()
    {
        // Make sure that the names of the children objects are "Joints" and "Surface", or set them in the IDE
        if (joints == null)
        {
            joints = transform.Find("Joints").gameObject;
        }
        if (surface == null)
        {
            surface = transform.Find("Surface").gameObject;
        }

        VoiceLine = GetComponent<AudioSource>();
        jointsanim = joints.GetComponent<Animator>();
        surfaceanim = surface.GetComponent<Animator>();
        SilhoutteAnim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (SilhoutteAnim.GetCurrentAnimatorStateInfo(0).IsName("EndThrow") && hasAnimPlayed == true)
        {
            jointsanim.Play("FadeJoints");
            surfaceanim.Play("SurfaceFade");
            Debug.Log("Anim played");
            hasAnimPlayed = false;
        }
    }

    public void fadeOut()
    {
        Debug.Log("Hit person with raycast");

        SilhoutteAnim.Play("Play");
        VoiceLine.Play();
        hasAnimPlayed = true;
    }
}
