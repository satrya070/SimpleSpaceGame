using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCanvas : MonoBehaviour
{
    GameObject ResultPanel;
    GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        ResultPanel = transform.Find("ResultPanel").gameObject;
        PausePanel = transform.Find("PausePanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevelResult();
        CheckPaused();        
    }

    void CheckLevelResult()
    {
        if(GameManager.GameManagerInstance.LevelEnded)
        {
            ResultPanel.SetActive(true);
        }
    }

    void CheckPaused()
    {
        if(GameManager.GameManagerInstance.LevelPaused & !PausePanel.activeSelf)
        {
            PausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!GameManager.GameManagerInstance.LevelPaused & PausePanel.activeSelf)
        {
            PausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        // else if(!GameManager.LevelStarted)
        // {
        //     PausePanel.SetActive(false);
        // }
    }
}
