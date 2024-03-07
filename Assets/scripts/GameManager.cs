using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Health playerHealth;
    bool restartingScene;
    float ReloadDelay = 5f;

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
