using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_RS_SilhouetteFadeEdit : MonoBehaviour
{
    public GameObject joints;
    private Animator jointsanim;

    public GameObject surface;
    private Animator surfaceanim;

    private AudioSource VoiceLine;

    private Animator SilhoutteAnim;

    public GameObject particlesystem;

    private GameObject player;

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

        //person = this.gameObject;
        VoiceLine = GetComponent<AudioSource>();
        jointsanim = joints.GetComponent<Animator>();
        surfaceanim = surface.GetComponent<Animator>();
        SilhoutteAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= PlayVoiceTime && enteredCollider == true)
        {
            VoiceLine.Play();

           

            enteredCollider = false;
            hasAnimPlayed = true;
        }

        if (SilhoutteAnim.GetCurrentAnimatorStateInfo(0).IsName("End") && hasAnimPlayed == true)
        {

            jointsanim.Play("FadeJoints");
            surfaceanim.Play("SurfaceFade");
            Debug.Log("Anim played");
            hasAnimPlayed = false;

        }
    }

    private bool enteredCollider = false;
    private float PlayVoiceTime;
    public float LineDelay = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Start Fade");
            SilhoutteAnim.Play("Play");
            jointsanim.Play("FadeJointsIn");
            surfaceanim.Play("SurfaceFadeIn");
            particlesystem.SetActive(false);
            Debug.Log("EnteredCollider");
            PlayVoiceTime = Time.time + LineDelay;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            enteredCollider = true;
        }
    }
}
