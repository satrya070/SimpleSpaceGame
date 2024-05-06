using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField]
    GameObject asteroid;

    [SerializeField]
    int numberAsteroidsAxis = 10;

    [SerializeField]
    int gridSpacing = 100;

    void Start()
    {
        PlaceAsteroids();
    }

    void Update()
    {
        
    }

    void PlaceAsteroids()
    {
        for(int x = 0; x < numberAsteroidsAxis; x++)
        {
            for (int y = 0; y < numberAsteroidsAxis; y++)
            {
                for (int z = 0; z < numberAsteroidsAxis; z++)
                {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(
            asteroid,
            new Vector3(
                transform.position.x + (x * gridSpacing) + AsteroidOffset(),
                transform.position.y + (y * gridSpacing) + AsteroidOffset(),
                transform.position.z + (z * gridSpacing) + AsteroidOffset()
            ),
            Quaternion.identity,
            transform
        );
    }

    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}
