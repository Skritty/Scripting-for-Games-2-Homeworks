using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper
{
    public static AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        GameObject obj = new GameObject("Audio2D");
        AudioSource source = obj.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        Object.Destroy(obj, clip.length);
        return source;
    }
}
