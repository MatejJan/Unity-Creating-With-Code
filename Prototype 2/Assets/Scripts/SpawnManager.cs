using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 15;
    private float spawnPositionZ = 30;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animalPrefab = animalPrefabs[animalIndex];

        Vector3 spawnPosition = new Vector3
        {
            x = Random.Range(-spawnRangeX, spawnRangeX),
            z = spawnPositionZ
        };

        Instantiate(animalPrefab, spawnPosition, animalPrefab.transform.rotation);
    }
}
