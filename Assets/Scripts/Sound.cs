using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource Source;

    public string Name;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume = 1f;

    public bool Loop;

    public bool PlayImmediately;

    public AudioMixerGroup AudioMixerGroup;
}