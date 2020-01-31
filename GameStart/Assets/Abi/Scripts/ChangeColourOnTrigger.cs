using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string ColourToUnlock;

    private GameObject go_colourManager;
    // Start is called before the first frame update
    void Start()
    {
        go_colourManager = GameObject.Find("Colour Manager");
        Debug.Assert(!go_colourManager, "There is no Colour Manager in the scene! That's wild please put one in our whole game revolves around colour! :,)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        go_colourManager.GetComponent<ColourManager>().bl_fadewhiteDone = false;
        go_colourManager.GetComponent<ColourManager>().str_unlockedColours.Add(ColourToUnlock);
        Destroy(gameObject);
    }
}
