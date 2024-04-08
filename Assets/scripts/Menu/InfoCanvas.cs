using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoCanvas : MonoBehaviour
{
    GameObject StartPanel;
    GameObject ResultPanel;
    GameObject PausePanel;
    GameObject GameoverPanel;

    TextMeshProUGUI StartTitle;
    TextMeshProUGUI StartText;
    TextMeshProUGUI ResultTitle;
    TextMeshProUGUI ResultText;

    // Start is called before the first frame update
    void Start()
    {
        // pause and show cursor on level load
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log($"Level start(infocanvas): {GameManager.GameManagerInstance.LevelStarted}, Paused(infocanvas):{GameManager.GameManagerInstance.LevelPaused}");

        StartPanel = transform.Find("StartPanel").gameObject;
        ResultPanel = transform.Find("ResultPanel").gameObject;
        PausePanel = transform.Find("PausePanel").gameObject;
        GameoverPanel = transform.Find("GameoverPanel").gameObject;

        StartTitle = StartPanel.transform.Find("InfoTitle").GetComponent<TextMeshProUGUI>();
        StartText = StartPanel.transform.Find("InfoText").GetComponent<TextMeshProUGUI>();
        ResultTitle = ResultPanel.transform.Find("InfoTitle").GetComponent<TextMeshProUGUI>();
        ResultText = ResultPanel.transform.Find("InfoText").GetComponent<TextMeshProUGUI>();

        SetlevelText();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevelResult();
        CheckPaused();        
    }

    void SetStartPanel()
    {
    }

    void CheckLevelResult()
    {
        if(GameManager.GameManagerInstance.LevelEnded)
        {
            if (GameManager.GameManagerInstance.LevelPassed)
            {
                Cursor.lockState = CursorLockMode.None;
                ResultPanel.SetActive(true);
            }
            else
            {
                GameoverPanel.SetActive(true);
            }
        }
    }

    void CheckPaused()
    {
        if(!GameManager.GameManagerInstance.LevelStarted & PausePanel.activeSelf)
        {
            PausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
        else if(GameManager.GameManagerInstance.LevelPaused & !PausePanel.activeSelf)
        {
            PausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!GameManager.GameManagerInstance.LevelPaused & PausePanel.activeSelf)
        {
            PausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void SetlevelText()
    {
        if(RaceManager.Instance)
        {
            StartTitle.text = "Welcome to Level 1!";
            StartText.text = "The goal to finish the racetrack in the given time. \n The red ring is the ring to follow in the course";

            ResultTitle.text = "Passed level 1!";
            ResultText.text = "Finished the race in {}!";
        }
        else if(meteorManager.instance)
        {
            StartTitle.text = "Welcome to Level 2!";
            StartText.text = "A Meteorshower is set on impacting our spacestation." +
            "Make sure the spacestation makes it through by destroying the meteors before impact.";

            //meteorManager.instance.SpaceStation.gameObject.GetComponent<Health>();
            ResultTitle.text = "Passed level 2!";
            ResultText.text = "Finished the race in {}!";
        }
    }

    public void StartLevel()
    {
        GameManager.GameManagerInstance.LevelStarted = true;
        StartPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
