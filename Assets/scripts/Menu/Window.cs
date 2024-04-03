using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    GameObject InfoCanvas;

    public void Start()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        InfoCanvas = transform.parent.parent.gameObject;
    }

    public void CloseWindow()
    {
        Debug.Log("closeWindow");
        GameManager.LevelStarted = true;
        InfoCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
