using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GM : MonoBehaviour
{

    #region Singleton
    static GM mSingleton = null;   //Create a shared (static) singleton

    public GM singleton
    {       //Make a Getter which will allow public R/O access (no setter)
        get
        {
            return mSingleton;
        }
    }

    // Awake is called just after the object is instantiated
    void Awake()
    {
        if (mSingleton == null)
        { //Only the first time
            mSingleton = this;  //Not the static references this object;
            DontDestroyOnLoad(gameObject);  //Stop the GO with this script being deleted   

            GameState = GameStates.Init;    //Init the game with the state machine
            StartCoroutine(GameStateCoRoutine());   //Run state machine CoRoutine

        }
        else if (mSingleton != this)
        { //If there is an attempt to make another kill it
            Destroy(gameObject);
        }
    }
    #endregion


    [SerializeField]
    private GameObject PausePanel;

    public enum GameStates
    {   //State the game is in
        None        //Pre start
        , Init
        , Startup
        , Play
        , Playing
        , Pause
    }
    GameStates mCurrentState = GameStates.None;    //Pre First State in initialisation
    //State machine handler
    public GameStates GameState
    {   //This may call itself recursivly
        set
        {
            if (value != mSingleton.mCurrentState)
            {  //Only change state if different from last one, or its first time its used
                mSingleton.ExitState(mSingleton.mCurrentState);  //Exit last state
                GameStates tNextState = mSingleton.EnterState(value); //Enter new state
                if (value == tNextState)
                { //If return state is final state, set it
                    mSingleton.mCurrentState = tNextState;
                }
                else
                {
                    mSingleton.mCurrentState = value;  //State we are in now
                    GameState = tNextState; //If not we need to change state again, until we reach the final one
                }
            }
        }
        get
        {
            return mSingleton.mCurrentState;   //Get Current State
        }
    }

    //Used to clear up after a state is exited
    private void ExitState(GameStates vState)
    {
        Debug.LogFormat("Exit State {0}", vState);
        switch (vState)
        {
            case GameStates.Pause:
                PausePanel = GameObject.Find("Pause Panel");
                PausePanel.SetActive(false);

                break;
            default:    //No Action
                break;
        }
    }

    //Used to set up a new state
    private GameStates EnterState(GameStates vState)
    {
        Debug.LogFormat("Enter State {0}", vState);
        switch (vState)
        {

            case GameStates.Init:
                return GameStates.Play;


            case GameStates.Play:
                PausePanel.SetActive(false);
                return GameStates.Playing;
                

            case GameStates.Pause:
                PausePanel.SetActive(true);
                break;


            default:    //No Action
                break;
        }
        return vState;  //Default just return state we entered
    }

    IEnumerator GameStateCoRoutine()
    {
        do
        {
            switch (GameState)
            {
                

                case GameStates.Playing:
                    {
                        if (Input.GetKey(KeyCode.Escape))
                        {
                            GameState = GameStates.Pause;
                        }
                        
                    }
                    break;



                default:    //No Action
                    break;
            }
            yield return new WaitForSeconds(0.1f);  //Wait for a 10th of a second before runnign again, lets other stuff process
        } while (true); //Never End
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
