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
    private float TimeTakenToCompleteAnimation;

    private BoxCollider bx_collider;
    // Start is called before the first frame update
    void Start()
    {
        go_PC = GameObject.Find("FPSController");
        an_animal = go_animal.GetComponent<Animator>();
        an_controller = go_controller.GetComponent<Animator>();
        bx_collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == go_PC)
        {
            an_animal.SetBool("isRunning", true);
            an_controller.SetBool("isTriggered", true);
            StartCoroutine("ReturnToIdle");
            Destroy(bx_collider);
        }
    }

    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(TimeTakenToCompleteAnimation);
        an_animal.SetBool("isRunning", false);
        an_animal.SetBool("isIdle", true);
    }
}
