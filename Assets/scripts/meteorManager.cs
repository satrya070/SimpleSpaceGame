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

    int MeteorsSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Impactpoints = GameObject.FindWithTag("Protectable");
        spawnPoints = Impactpoints.GetComponentsInChildren<Transform>();
        spawnPoints = spawnPoints.Skip(1).ToArray();  // exclude transform being searched in transform

        StartCoroutine(RandomMeteorSpawner());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RandomMeteorSpawner()
    {
        while(MeteorsSpawned < 5)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            SpawnMeteor();
            MeteorsSpawned += 1;
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = Random.insideUnitSphere;
        Debug.Log(spawnPosition);
        GameObject asteroid = Instantiate(asteroidPrefab, transform.position + (spawnPosition * spawnRadius), transform.rotation);
        CrashingMeteor CrashComp = asteroid.GetComponent<CrashingMeteor>();
        int CrashPointPick = Random.Range(0, 3);
        CrashComp.crashPoint = spawnPoints[CrashPointPick];
    }
}
