using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRun : MonoBehaviour
{
    private GameObject go_PC;

    [SerializeField]
    private GameObject go_animal;
    private Animator an_animal;
    [SerializeField]
    private GameObject go_controller;
    private Animator an_controller;
    [SerializeField]
    private bool IsShark;

    [SerializeField]
    private float TimeTakenToCompleteAnimation;

    private BoxCollider bx_collider;
    // Start is called before the first frame update
    void Start()
    {
        go_PC = GameObject.Find("FPSController");
        an_animal = go_animal.GetComponent<Animator>();
        an_controller = go_controller.GetComponent<Animator>();
        bx_collider = gameObject.GetComponent<BoxCollider>();
        if (IsShark)
        {
            an_animal.SetBool("isSwimming", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == go_PC)
        {
            an_controller.SetBool("isTriggered", true);
            if (!IsShark)
            {
                an_animal.SetBool("isRunning", true);
                //StartCoroutine("ReturnToIdle");
            }
            StartCoroutine("ReturnToIdle");


            Destroy(bx_collider);
        }
    }

    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(TimeTakenToCompleteAnimation);
        if (!IsShark)
        {
            an_animal.SetBool("isRunning", false);
            an_animal.SetBool("isIdle", true);
        }
        else
        {
            an_controller.SetBool("isTriggered", false);
        }
    }
}
