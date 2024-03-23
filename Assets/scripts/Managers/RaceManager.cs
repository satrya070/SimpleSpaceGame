using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{   
    public static RaceManager Instance;

    [SerializeField]
    public List<GameObject> racePoints;

    public float Countdown = 0f;
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
            Countdown += Time.deltaTime;
            Debug.Log(Countdown);
        }
    }
}
