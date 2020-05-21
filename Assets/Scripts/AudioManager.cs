using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] m_Sounds = { };

    public static AudioManager Instance = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Multiple AudioManagers are in scene! This with name " + gameObject.name + " and already existing with name " + Instance.name);
            DestroyImmediate(this);
        }

        Instance = this;

        foreach (Sound sound in m_Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.loop = sound.Loop;
            sound.Source.outputAudioMixerGroup = sound.AudioMixerGroup;

            if (sound.PlayImmediately)
            {
                sound.Source.Play();
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find<Sound>(m_Sounds, sound => sound.Name == name);
        if (s != null)
        {
            s.Source.Play();
        }
        else
        {
            Debug.Log("Unknown sound: " + name);
        }
    }
}