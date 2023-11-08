using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource[] soundSources;
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
        if(soundSources.Length != 0) PlayerPrefs.SetFloat("SoundVolume", soundSources[0].volume);
        else PlayerPrefs.SetFloat("SoundVolume", 0);
    }
    public void LoadSettings()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        for (int i = 0; i < soundSources.Length; i++)
        {
            if (PlayerPrefs.HasKey("SoundVolume"))
            {
                soundSources[i].volume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }

    }
    public float[] GetSettings()
    {
        float[] respond = new float[2];
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            respond[0] = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            respond[1] = PlayerPrefs.GetFloat("SoundVolume");
        }
        return respond;
    }
    public void LoadAudio(AudioClip[] clips)
    {
        musicSource.clip = clips[0];
        musicSource.loop = true;
        musicSource.Play();
        for(int i = 0; i < soundSources.Length; i++)
        {
            soundSources[i].clip = clips[i + 1];
        }
    }
}
