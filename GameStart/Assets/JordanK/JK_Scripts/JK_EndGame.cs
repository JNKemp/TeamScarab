using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JK_EndGame : MonoBehaviour
{
    private float EndGameTime;
    public float DelayToEnd = 10f;
    private bool StartEnd = false;

    public string MenuScene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndGameTime = Time.time + DelayToEnd;
            StartEnd = true;
        }
    }
    private void Update()
    {
        if ((Time.time >= EndGameTime) && (StartEnd == true))
        {
            StartEnd = false;
            SceneManager.LoadScene(MenuScene);
        }
    }
}
