using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipThruster : MonoBehaviour
{
    ParticleSystem particleSystem;
    float currentEmissionRate;
    Rigidbody Player;
    ParticleSystem.EmissionModule emission;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        emission = particleSystem.emission;
        currentEmissionRate = particleSystem.emission.rateOverTime.constant;
        Player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentEmissionRate);
        if(Player.velocity.magnitude > 20f)
        {
            Debug.Log($"{Player.velocity.magnitude} - {currentEmissionRate}");
            emission.rateOverTime = 13f;
        }
        else
        {
            emission.rateOverTime = 5f;
        }
    }
}
