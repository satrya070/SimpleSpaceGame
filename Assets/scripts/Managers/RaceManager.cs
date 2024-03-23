using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{   
    public static RaceManager Instance;

    [SerializeField]
    public List<GameObject> racePoints;

    [SerializeField] TMP_Text timerText;
    public float Countdown = 60f;
    public bool OnCount = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownRace();
    }

    void CountdownRace()
    {
        if(OnCount)
        {
            Countdown -= Time.deltaTime;
            //Debug.Log(Countdown);
            int minutes = Mathf.FloorToInt(Countdown / 60);
            int seconds = Mathf.FloorToInt(Countdown % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
