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
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Clip no found.");
        }
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip soundClip = GetSoundClip(sound);
        soundMusic.clip = soundClip;
        soundMusic.volume = 0.4f;
        soundMusic.Play();
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        return Array.Find(SoundMap, item => item.soundType == sound).soundClip;
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
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
