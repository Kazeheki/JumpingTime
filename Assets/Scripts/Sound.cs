using System;
using UnityEngine;

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
}