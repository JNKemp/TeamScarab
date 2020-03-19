using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquariumTeleport : MonoBehaviour
{
    private GameObject Player;
    private BoxCollider bx_collider;
    [SerializeField]
    private GameObject PlaceToTeleport;
    private CharacterController cc_player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPSController");
        cc_player = Player.GetComponent<CharacterController>();
        bx_collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Destroy(bx_collider);
            StartCoroutine(Teleport());
            //cc_player.enabled = false;
            //Player.transform.position = PlaceToTeleport.transform.position;
            //cc_player.enabled = true;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1.5f);
        cc_player.enabled = false;
        Player.transform.position = PlaceToTeleport.transform.position;
        cc_player.enabled = true;
    }
}
