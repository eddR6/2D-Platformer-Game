using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public SoundType[] SoundMap;
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayMusic(Sounds.Music);
    }
    void Update()
    {   
    }
    public void Play(Sounds sound)
    {
        SoundType soundType = GetSoundClip(sound);
        if (soundType != null)
        {
            soundEffect.loop = soundType.looping;
            soundEffect.volume = soundType.volume;
            soundEffect.PlayOneShot(soundType.soundClip);
        }
        else
        {
            Debug.LogWarning("Clip no found.");
        }
    }
    public void PlayMusic(Sounds sound)
    {
        SoundType soundType = GetSoundClip(sound);
        soundMusic.clip = soundType.soundClip;
        soundMusic.volume = soundType.volume;
        soundMusic.loop = soundType.looping;
        soundMusic.Play();
    }

    private SoundType GetSoundClip(Sounds sound)
    {
        if (sound != null)
        {
            return Array.Find(SoundMap, item => item.soundType == sound);
        }
        return null;
        
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
    [Range(0.0f,1.0f)]
    public float volume;
    public bool looping;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    LevelLocked,
    LevelComplete
}
