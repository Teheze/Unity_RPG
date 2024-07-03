using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Menu");
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musicSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = System.Array.Find(sfxSounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySFX(string name, float volumePercentage)
    {
        Sound s = System.Array.Find(sfxSounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
        }

        else
        {
            volumePercentage = musicSource.volume * volumePercentage;
            sfxSource.PlayOneShot(s.clip, volumePercentage);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX() 
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}