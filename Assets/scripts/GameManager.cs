using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Health playerHealth;
    bool restartingScene;

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
    }

    void PlayerDied()
    {
        if(playerHealth.currentHealth <= 0)
        {
            if(!restartingScene)
            {
                restartingScene = true;
                Debug.Log("Player DIED!");
            }

        }
    }
}
