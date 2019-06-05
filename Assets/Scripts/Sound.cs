using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sounds/Sound")]
public class Sound : ScriptableObject
{
    public AudioClip clip;

    public bool loop;
    [Range(0f, 1f)] public float volume = 1;
    [Range(.1f, 3f)] public float pitch = 1;

    [HideInInspector] public AudioSource source;
}