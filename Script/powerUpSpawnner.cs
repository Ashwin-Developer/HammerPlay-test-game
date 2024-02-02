using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawnner : MonoBehaviour
{
    public GameObject[] powerUpPrefab;
    public Transform[] spawnPosition;



    private void Start()
    {
        StartCoroutine(powerUpWave());

    }



    IEnumerator powerUpWave()
    {

        int spawnRate = 10;
        while (true)
        {


            yield return new WaitForSeconds(spawnRate);

            int randpowerUp = Random.Range(0, powerUpPrefab.Length);
            GameObject obstacleToSpawn = powerUpPrefab[randpowerUp];

            int randPosition = Random.Range(0, spawnPosition.Length);
            Transform positionToSpawn = spawnPosition[randPosition];

            Instantiate(obstacleToSpawn, positionToSpawn.position, Quaternion.identity);


        }
    }
}
