using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public Health playerHealth;
    public bool restartingScene;
    float LevelReloadTime = 3f;
    
    public bool LevelStarted;
    public bool LevelEnded;
    public bool LevelPassed;
    public bool LevelPaused;

    public static GameManager GameManagerInstance;

    public Dictionary<int, Action> LevelEndConditions = new Dictionary<int, Action>();
    public Dictionary<Tuple<string, string>, int> specialBehaviour = new Dictionary<Tuple<string, string>, int>();

    void Awake() {
        Debug.Log($"LevelStarted: {LevelStarted}| LevelPaused: {LevelPaused}");
        if(GameManagerInstance != null && GameManagerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            GameManagerInstance = this;
        }

        // specific situations where damage should be different
        specialBehaviour.Add(Tuple.Create("Player", "SpaceStation"), 1);

        // populate end win-lose conditions
        LevelEndConditions.Add(1, MonitorRace);
        LevelEndConditions.Add(2, MonitorMeteors);
        LevelEndConditions.Add(3, MonitorHunters);

        // on each scene reload(restart/nextlevel) reset manager variables
        ResetGamemanagerVariables();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        //AudioManager.Instance.PlayMusic($"level_{SceneManager.GetActiveScene().buildIndex}_track");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDied();

        // No need to check win/lose conditions for menu
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            LevelEndConditions[SceneManager.GetActiveScene().buildIndex]();
        }
    }

    void PlayerDied()
    {
        if(playerHealth)
        {
            if(playerHealth.currentHealth <= 0)
            {
                // TODO player has died window
                RestartLevel();
            }
        }
    }

    public void MonitorRace()
    {
        if(RaceManager.Instance & RaceManager.Instance.RaceFinished & !LevelEnded)
        {
            if(RaceManager.Instance & RaceManager.Instance.RacePassed)
            {
                LevelEnded = true;
                LevelPassed = true;
                Debug.Log($"Passed mission: {LevelEnded}");
            }
            else if(RaceManager.Instance & !RaceManager.Instance.RacePassed)
            {
                // fail window
                LevelEnded = true;
                RestartLevel();
            }
        }
    }

    public void MonitorMeteors()
    {
        if(meteorManager.instance & !LevelEnded)
        {
            if(!meteorManager.instance.SpaceStation)
            {
                Debug.Log("SpaceStation dead!!");
                LevelEnded = true;
                RestartLevel();
            }

            if(meteorManager.instance.MeteorsPassed)
            {
                LevelEnded = true;
                LevelPassed= true;
                Debug.Log("passed!!! next level");
            }
        }
    }

    public void MonitorHunters()
    {
        if(LevelPassed & !LevelEnded)
        {
            Debug.Log("Killed all emenymies");
            LevelEnded = true;
        }
    }

    public void ResetGamemanagerVariables()
    {
        GameManagerInstance.LevelEnded = false;
        GameManagerInstance.LevelPassed = false;
        GameManagerInstance.LevelStarted = false;
        GameManagerInstance.LevelPaused = false;
    }

    public void RestartLevel()
    {
        if(!restartingScene)
        {
            //LevelPaused = false;
            //Debug.Log("restarting missoin");
            restartingScene = true;
            ResetGamemanagerVariables();
            //Debug.Log("caliing coroutine restarts");
            StartCoroutine(ReloadSceneDelay());
        }
    }

    IEnumerator ReloadSceneDelay()
    {
        yield return new WaitForSeconds(LevelReloadTime);

        restartingScene = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
