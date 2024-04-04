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

    RaceManager raceManager;
    meteorManager meteorManager;
    
    public static Dictionary<Tuple<string, string>, float> specialHits = new Dictionary<Tuple<string, string>, float>();
    public static bool LevelStarted;

    public static bool LevelEnded;
    public static bool LevelPassed;

    public Dictionary<int, Action> LevelEndConditions = new Dictionary<int, Action>();

    void Awake() {
        GameObject raceManagerObject = GameObject.FindWithTag("RaceManager");
        raceManager = raceManagerObject ? raceManagerObject.GetComponent<RaceManager>() : null;

        GameObject meteorManagerObject = GameObject.FindWithTag("MeteorManager");
        meteorManager = meteorManagerObject ? meteorManagerObject.GetComponent<meteorManager>() : null;

        // specific situations where damage should be different
        Globals.specialBehaviour.Add(Tuple.Create("Player", "SpaceStation"), 1);

        // populate end win-lose conditions
        LevelEndConditions.Add(1, MonitorRace);
        LevelEndConditions.Add(2, MonitorMeteors);
        // TODO add lv3 AI manager
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();

        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDied();
        LevelEndConditions[SceneManager.GetActiveScene().buildIndex]();
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
                Debug.Log(GameManager.LevelEnded);
            }
        }
    }

    // public void MonitorAI() TODO implement level 3
    // {
    //     if()
    // }

    public void RestartLevel()
    {
        if(!restartingScene)
        {
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
