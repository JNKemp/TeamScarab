using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    private GameObject go_GameManager;

    [SerializeField]
    private string MainMenuSceneName;
    // Start is called before the first frame update
    void Start()
    {
        go_GameManager = GameObject.Find("Game Manager");
    }

    public void Resume()
    {
        go_GameManager.GetComponent<GM>().GameState = GM.GameStates.Playing;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
