using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    public Sound[] sounds;

    public static AudioManager _instance;
    [HideInInspector]
    public float masterVolume = 0;
    [HideInInspector]
    public float dialogeVolume = 0;
    [HideInInspector]
    public float SoundeEffectsVolume = 0;

    
    
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

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetDialogeVolume(float volume)
    {
        dialogeVolume = volume;
        audioMixer.SetFloat("dialogeVolume", volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        SoundeEffectsVolume = volume;
        audioMixer.SetFloat("soundEffectsVolume", volume);
    }
}
