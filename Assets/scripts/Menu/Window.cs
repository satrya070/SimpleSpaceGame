using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    GameObject StartPanel;

    public void Start()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        StartPanel = transform.parent.gameObject;
    }

    public void CloseWindow()
    {
        GameManager.GameManagerInstance.LevelStarted = true;
        Debug.Log($"Level started?: {GameManager.GameManagerInstance.LevelStarted}");
        StartPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
