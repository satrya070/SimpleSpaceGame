using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0); // get id from mainmenu
    }

    public void RestartLevel()
    {
        gameObject.SetActive(false);
        GameManager.GameManagerInstance.LevelStarted = false;
        GameManager.GameManagerInstance.LevelPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
