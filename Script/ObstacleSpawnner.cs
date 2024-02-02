using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public Transform[] spawnPosition;
    public int spawnRateDecrement = 1;


    private void Start()
    {
        StartCoroutine(obstacleWave());

    }



    IEnumerator obstacleWave()
    {

        int spawnRate = 5;
        while (true)
        {

            
            yield return new WaitForSeconds(spawnRate);

            int randObstacle = Random.Range(0, obstaclePrefab.Length);
            GameObject obstacleToSpawn = obstaclePrefab[randObstacle];

            int randPosition = Random.Range(0, spawnPosition.Length);
            Transform positionToSpawn = spawnPosition[randPosition];

            Instantiate(obstacleToSpawn,positionToSpawn.position,Quaternion.identity);

            spawnRate -= spawnRateDecrement;

            spawnRate = Mathf.Max(spawnRate, 1); //make sure spawnrate doesn't go below 1

        }
    }
}
