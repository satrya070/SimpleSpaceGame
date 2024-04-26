using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        //PlayMusic("LevelSound");
    }

    public void PlayMusic(string name) {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if(sound == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySfx(string name) {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if(sound == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }
}
