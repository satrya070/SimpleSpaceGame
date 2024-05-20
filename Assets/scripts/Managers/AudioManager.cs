using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private int currentSceneIndex;
    [SerializeField] bool playMusic;

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
        PlayMusic($"level_{SceneManager.GetActiveScene().buildIndex}_track");
    }

    public void PlayMusic(string name) {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if(sound == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            if (playMusic)
            {
                musicSource.clip = sound.clip;
                musicSource.Play();
            }
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"sceneIndex: {scene.buildIndex}");
        if(currentSceneIndex != scene.buildIndex)
        {
            PlayMusic($"level_{scene.buildIndex}_track");
            currentSceneIndex = scene.buildIndex;
        }
    }
}
