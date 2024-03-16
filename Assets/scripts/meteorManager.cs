using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class meteorManager : MonoBehaviour
{
    float spawnRadius = 50f;

    [SerializeField]
    GameObject asteroidPrefab;

    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Impactpoints = GameObject.FindWithTag("Protectable");
        spawnPoints = Impactpoints.GetComponentsInChildren<Transform>();
        spawnPoints = spawnPoints.Skip(1).ToArray();  // exclude transform being searched in transform

        Vector3 spawnPosition = Random.insideUnitSphere;
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition * spawnRadius, transform.rotation);
        CrashingMeteor CrashComp = asteroid.GetComponent<CrashingMeteor>();
        CrashComp.crashPoint = spawnPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
    }
}
