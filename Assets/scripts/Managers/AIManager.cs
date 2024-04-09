using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyAIResult());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
