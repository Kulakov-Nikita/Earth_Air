using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource[] soundSources;
    public void ChangeMusicVolume(Slider slider)
    {
        musicSource.volume = slider.value;
    }
    public void ChangeSoundVolume(Slider slider)
    {
        Debug.Log(slider.value);
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume",musicSource.volume);
        for (int i = 0; i < soundSources.Length; i++)
        {
            string name = "SoundVolume" + i;
            PlayerPrefs.SetFloat(name, soundSources[i].volume);
        }
    }
    public void LoadSettings()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        for (int i = 0; i < soundSources.Length; i++)
        {
            string name = "SoundVolume" + i;
            if (PlayerPrefs.HasKey(name))
            {
                soundSources[i].volume = PlayerPrefs.GetFloat(name);
            }
        }
    }
    public void LoadAudio(AudioClip[] clips)
    {
        musicSource.clip = clips[0];
        for(int i = 0; i < soundSources.Length; i++)
        {
            soundSources[i].clip = clips[i + 1];
        }
    }
}
