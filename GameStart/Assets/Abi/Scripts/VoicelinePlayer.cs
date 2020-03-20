using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoicelinePlayer : MonoBehaviour
{
    private AudioSource as_voiceline;

    public AudioClip[] voicelines;

    private int int_voicelineNumber;

    public GameObject SubtitlePanel;
    public string[] Subtitles;
    private TextMeshProUGUI currentSubtitles;
    // Start is called before the first frame update
    void Start()
    {
        as_voiceline = GetComponent<AudioSource>();
        int_voicelineNumber = 0;
        SubtitlePanel.SetActive(false);
        currentSubtitles = SubtitlePanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (voicelines.Length != 0)
        {
            if (!as_voiceline.isPlaying)
            {
                if (int_voicelineNumber > (voicelines.Length - 1))
                {
                    int_voicelineNumber = 0;
                    voicelines = new AudioClip[0];
                    Subtitles = new string[0];
                    SubtitlePanel.SetActive(false);
                    currentSubtitles.text = "";
                }
                else
                {
                    as_voiceline.clip = voicelines[int_voicelineNumber];
                    as_voiceline.Play();
                    SubtitlePanel.SetActive(true);
                    currentSubtitles.text = Subtitles[int_voicelineNumber];
                    int_voicelineNumber++;
                    
                }
            }
        }

    }    
}
