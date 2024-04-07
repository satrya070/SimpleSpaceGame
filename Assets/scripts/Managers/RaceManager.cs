using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{   
    public static RaceManager Instance;

    [SerializeField]
    public List<GameObject> racePoints;

    [SerializeField] public TMP_Text timerText;
    public float Countdown = 60f;
    public bool OnCount = false;
    public bool RaceFinished = false;
    public bool RacePassed = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownRace();
        RaceResult();
    }

    void CountdownRace()
    {
        if(OnCount)
        {
            Countdown -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(Countdown / 60);
            int seconds = Mathf.FloorToInt(Countdown % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void RaceResult()
    {
        if(!RaceFinished)
        {
            if(racePoints.Count == 0 & Countdown >= 0f)
            {
                Debug.Log("Succesfully completed the mission!");
                RacePassed = true;
                RaceFinished = true;
                timerText.gameObject.SetActive(false);
            }
            else if(racePoints.Count > 0f & Countdown < 0f)
            {
                Debug.Log("Failed the mission!");
                RaceFinished = true;
                timerText.gameObject.SetActive(false);
            }
        }
    }
}
