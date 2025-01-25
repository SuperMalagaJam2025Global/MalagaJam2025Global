using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] obstacles;

    public float spawnTime = 2f;

    public Transform spawnPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnTime = 2f;
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
