using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class meteorManager : MonoBehaviour
{
    public static meteorManager instance;
    float spawnRadius = 80f;

    [SerializeField]
    GameObject asteroidPrefab;
    [SerializeField] int MeteorsToSpawn = 10;

    public Transform[] spawnPoints;

    int MeteorsSpawned = 0;
    public bool MeteorsPassed = false;

    public GameObject SpaceStation;

    void Awake()
    {
        instance = this;
    }

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
        while(MeteorsSpawned < MeteorsToSpawn & SpaceStation)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            SpawnMeteor();
            MeteorsSpawned += 1;

            // coroutine to check when exactly the last meteor is destroyed
            if(MeteorsSpawned == MeteorsToSpawn)
            {
                yield return StartCoroutine(MeteorResult());
            }
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = Random.insideUnitSphere;
        //Debug.Log(spawnPosition);
        GameObject asteroid = Instantiate(asteroidPrefab, transform.position + (spawnPosition * spawnRadius), transform.rotation);
        CrashingMeteor CrashComp = asteroid.GetComponent<CrashingMeteor>();
        int CrashPointPick = Random.Range(0, 3);
        CrashComp.crashPoint = spawnPoints[CrashPointPick];
    }

    IEnumerator MeteorResult()
    {
        while(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            Debug.Log("Enemies still left!");

            yield return new WaitForSeconds(1.5f);
        }
        
        Debug.Log("meteors DONE");
        MeteorsPassed = true;
    }
}
