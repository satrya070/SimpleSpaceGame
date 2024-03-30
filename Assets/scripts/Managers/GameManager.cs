using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    Health playerHealth;
    bool restartingScene;
    float ReloadDelay = 5f;
    
    public static Dictionary<Tuple<string, string>, float> specialHits = new Dictionary<Tuple<string, string>, float>();
    public static bool LevelStarted;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();

        // specific situations where damage should be different
        //specialHits.Add(Tuple.Create("Player", "SpaceStation"), 1f);
        Globals.specialBehaviour.Add(Tuple.Create("Player", "SpaceStation"), 1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDied();
    }

    void PlayerDied()
    {
        if(playerHealth.currentHealth <= 0)
        {
            if(!restartingScene)
            {
                restartingScene = true;
                Debug.Log("Player DIED!");

                StartCoroutine(ReloadSceneDelay());
            }

        }
    }

    IEnumerator ReloadSceneDelay()
    {
        yield return new WaitForSeconds(ReloadDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
