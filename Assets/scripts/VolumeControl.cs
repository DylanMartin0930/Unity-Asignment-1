using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    private static readonly string firstPlay = "firstPlay";
    private static readonly string volumePref = "volumePref";

    private int firstPlayInt;
    public Slider volumeSlider;
    private float volumeFloat;

    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);

        if(firstPlayInt == 0)
        {
            volumeFloat = .0125f;
            volumeSlider.value = volumeFloat;
            PlayerPrefs.SetFloat(volumePref, volumeFloat);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
            volumeFloat = PlayerPrefs.GetFloat(volumePref);
            volumeSlider.value = volumeFloat;
        }
    }

    
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(volumePref, volumeSlider.value);
    }
    
    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = volumeSlider.value;

        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = volumeSlider.value;
        }
    }




}
