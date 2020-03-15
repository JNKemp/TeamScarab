using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelTrigger : MonoBehaviour
{
    public enum location
    {
        Blank,
        Forest,
        Beach,
        Aquarium,
    }
    [SerializeField]
    private location LevelEntered;
    private int in_levelEntered;

    private GameObject Player;
    private GameObject go_SkyboxManager;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPSController");
        go_SkyboxManager = GameObject.Find("Skybox Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            if (LevelEntered == location.Forest)
            {
                in_levelEntered = 1;
            }
            if (LevelEntered == location.Beach)
            {
                in_levelEntered = 2;
            }
            if (LevelEntered == location.Aquarium)
            {
                in_levelEntered = 3;
            }

            go_SkyboxManager.GetComponent<SkyboxManager>().in_currentLevel = in_levelEntered;
        }
    }
}
