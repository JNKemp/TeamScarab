using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private GameObject intro;
    public void LoadScene(string level)
    {
        JK_DoorOpen.isDoorOpen = false;
        if(level == "MainLevel")
        {
            intro.SetActive(true);
        }
        SceneManager.LoadScene(level);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
