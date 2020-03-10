using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicelineSendTMP : MonoBehaviour
{
    private GameObject Player;
    private GameObject DialogueController;
    [SerializeField]
    private AudioClip[] VoicelinesInOrder;
    private AudioClip[] TempAudioClips;
    [SerializeField]
    private string[] SubtitlesInOrder;
    private string[] TempSubtitles;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPSController");
        DialogueController = GameObject.Find("DialogueController");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            //Adds voicelines to the array in the Dialogue Manager when the player steps into the trigger
            //Even if the player steps in multiple trigger boxes those voiceslines are added and not overwritten!
            TempAudioClips = new AudioClip[DialogueController.GetComponent<VoicelinePlayer>().voicelines.Length + VoicelinesInOrder.Length];
            DialogueController.GetComponent<VoicelinePlayer>().voicelines.CopyTo(TempAudioClips, 0);
            VoicelinesInOrder.CopyTo(TempAudioClips, DialogueController.GetComponent<VoicelinePlayer>().voicelines.Length);
            //Set the voicelines
            DialogueController.GetComponent<VoicelinePlayer>().voicelines = TempAudioClips;

            TempSubtitles = new string[DialogueController.GetComponent<VoicelinePlayer>().Subtitles.Length + SubtitlesInOrder.Length];
            DialogueController.GetComponent<VoicelinePlayer>().Subtitles.CopyTo(TempSubtitles, 0);
            SubtitlesInOrder.CopyTo(TempSubtitles, DialogueController.GetComponent<VoicelinePlayer>().Subtitles.Length);
            //Set the subtitles
            DialogueController.GetComponent<VoicelinePlayer>().Subtitles = TempSubtitles;

            Destroy(gameObject);
        }
    }
}
