using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcaleSpawner : MonoBehaviour
{
    // public GameObject obstcale;
    public static ObstcaleSpawner instance;
    public GameObject[] obstacles;

    public bool gameOver = false;

    public float minSpawnTime, maxSpawnTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        float waitTime = 1f;
        yield return new WaitForSeconds(waitTime);

        while (!gameOver)
        {
            SpawnObstcale();
            waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }



    void SpawnObstcale()
    {
        int random = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[random], transform.position, Quaternion.identity); 
    }

}
