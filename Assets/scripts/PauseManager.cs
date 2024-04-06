using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) & GameManager.GameManagerInstance.LevelStarted)
        {
            if(GameManager.GameManagerInstance.LevelPaused)
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
            GameManager.GameManagerInstance.LevelPaused = true;
        }

        void ResumeGame()
        {
            Time.timeScale = 1f;
            GameManager.GameManagerInstance.LevelPaused = false;
        }
    }
}
