using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    Health playerHealth;
    bool restartingScene;
    float LevelReloadTime = 5f;

    public RaceManager raceManager;
    public meteorManager meteorManager;
    
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


        GameObject raceManagerObject = GameObject.FindWithTag("RaceManager");
        raceManager = raceManagerObject ? raceManagerObject.GetComponent<RaceManager>() : null;

        GameObject meteorManagerObject = GameObject.FindWithTag("MeteorManager");
        meteorManager = meteorManagerObject ? meteorManagerObject.GetComponent<meteorManager>() : null;

        // specific situations where damage should be different
        specialBehaviour.Add(Tuple.Create("Player", "SpaceStation"), 1);

        // populate end win-lose conditions
        LevelEndConditions.Add(1, MonitorRace);
        LevelEndConditions.Add(2, MonitorMeteors);
        LevelEndConditions.Add(3, MonitorHunters);
        // TODO add lv3 AI manager
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();
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
        if(playerHealth.currentHealth <= 0)
        {
            // TODO player has died window
            RestartLevel();
        }
    }

    public void MonitorRace()
    {
        if(raceManager & !LevelEnded)
        {
            if(raceManager.RaceFinished & raceManager.RacePassed)
            {
                Debug.Log("Passed mission");
                LevelEnded = true;
            }
            else if(raceManager.RaceFinished & !raceManager.RacePassed)
            {
                Debug.Log("Failed mission");
                // fail window
                LevelEnded = true;
                RestartLevel();
            }
        }
    }

    public void MonitorMeteors()
    {
        if(meteorManager & !LevelEnded)
        {
            if(!meteorManager.SpaceStation)
            {
                Debug.Log("SpaceStation dead!!");
                LevelEnded = true;
                RestartLevel();
            }

            if(meteorManager.MeteorsPassed)
            {
                LevelEnded = true;
                Debug.Log("passed!!! next level");
                Debug.Log(GameManager.GameManagerInstance.LevelEnded);
            }
        }
    }

    public void MonitorHunters()
    {
    }

    public void RestartLevel()
    {
        if(!restartingScene)
        {
            LevelPaused = false;
            restartingScene = true;
            StartCoroutine(ReloadSceneDelay());
        }
    }

    IEnumerator ReloadSceneDelay()
    {
        yield return new WaitForSeconds(LevelReloadTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
