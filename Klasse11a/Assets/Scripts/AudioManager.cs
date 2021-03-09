﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    public Sound[] sounds;

    public static AudioManager _instance;

    public float masterVolume = 1;
    
    
    void Awake()
    {

        if (_instance == null) _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(this.gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.output;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    public void Playe(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        if (s.source.isPlaying == false)
        {
            s.source.Play();
        }
        
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public void SetVolume(float volume)
    {
        masterVolume = volume;
        Debug.Log(masterVolume);
        audioMixer.SetFloat("volume", volume);
    }
}
