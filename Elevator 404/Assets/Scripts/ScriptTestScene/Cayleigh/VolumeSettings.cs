using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider voiceSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetVoiceVolume();
        }
        
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetVoiceVolume()
    {
        float volume = voiceSlider.value;
        myMixer.SetFloat("Voice", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("voiceVolume", volume);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        voiceSlider.value = PlayerPrefs.GetFloat("voiceVolume");

        SetMusicVolume();
        SetVoiceVolume();
    }
}
