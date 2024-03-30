using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) & GameManager.LevelStarted)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        void PauseGame()
        {
            Time.timeScale = 0f;
            isPaused = true;
            //pauseMenu.SetActive(true);
        }

        void ResumeGame()
        {
            Time.timeScale = 1f;
            isPaused = false;
            //pauseMenu.SetActive(false);
        }
    }
}
