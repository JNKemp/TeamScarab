using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]
    private GameObject ToBeDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Destroy(ToBeDestroyed);
        }
    }
}
