using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCanvas : MonoBehaviour
{
    GameObject ResultPanel;

    // Start is called before the first frame update
    void Start()
    {
        ResultPanel = transform.Find("ResultPanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.LevelEnded);
        if(GameManager.LevelEnded)
        {
            //Debug.Log("show result panel");
            ResultPanel.SetActive(true);
        }
        
    }
}
