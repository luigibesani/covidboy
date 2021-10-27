using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave 
{
    public string waveName;
    public int numberOfEnemies;
    public float spawnInternval;
}

public class WaveSpawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    public Transform[] spawnPoints;
    public GameObject[] typeOfEnemies;

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(6f);
        GameObject randomEnemy = typeOfEnemies[Random.Range(0, typeOfEnemies.Length)];
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
        StartCoroutine(SpawnWave());
    }

  }



