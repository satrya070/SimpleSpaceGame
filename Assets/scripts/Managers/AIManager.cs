using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject startEnemy;
    bool secondWaveStarted;

    // Start is called before the first frame update
    void Start()
    {
        startEnemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSecondWave();
    }

    IEnumerator EnemyAIResult()
    {
        while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            Debug.Log("Enemies still left!");

            yield return new WaitForSeconds(1.5f);
        }

        GameManager.GameManagerInstance.LevelPassed = true;
        GameManager.GameManagerInstance.LevelEnded = true;
    }

    void SpawnSecondWave()
    {
        if (startEnemy == null && secondWaveStarted == false)
        {
            Debug.Log("second wave started!");

            float spawnDistance = 200f;
            Vector3 playerLocation = GameObject.FindWithTag("Player").transform.position;
            //Vector3 enemySpawnLocation = playerLocation + Random.onUnitSphere * spawnDistance;
            //Vector3 enemySpawnLocation = playerLocation + Random.onUnitSphere * spawnDistance;

            //spawn 2 enemies
            Instantiate(enemyPrefab, playerLocation + Random.onUnitSphere * spawnDistance, transform.rotation);
            Instantiate(enemyPrefab, playerLocation + Random.onUnitSphere * spawnDistance, transform.rotation);
            secondWaveStarted = true;

            StartCoroutine(EnemyAIResult());
        }
    }
}
