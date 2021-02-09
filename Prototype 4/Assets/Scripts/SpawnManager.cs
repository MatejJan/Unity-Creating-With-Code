using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int waveNumber = 0;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int enemiesCount = GameObject.FindObjectsOfType<Enemy>().Length;

        if (enemiesCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition() + Vector3.up * 0.5f, Quaternion.identity);
        }
    }

    private void SpawnEnemyWave(int enemiesCount)
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-180f, 180f), 0);
        return Matrix4x4.Rotate(randomRotation).MultiplyVector(Vector3.right * spawnRadius);
    }
}
