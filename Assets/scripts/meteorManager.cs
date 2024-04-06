using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class meteorManager : MonoBehaviour
{
    float spawnRadius = 100f;

    [SerializeField]
    GameObject asteroidPrefab;

    public Transform[] spawnPoints;

    int MeteorsSpawned = 0;
    public bool MeteorsPassed = false;

    public GameObject SpaceStation;

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
        while(MeteorsSpawned < 5 & SpaceStation)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            SpawnMeteor();
            MeteorsSpawned += 1;

            if(MeteorsSpawned == 5)
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
