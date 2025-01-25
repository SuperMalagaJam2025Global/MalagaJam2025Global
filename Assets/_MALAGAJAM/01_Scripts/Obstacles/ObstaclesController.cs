using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] obstacles;
    public GameObject bubbles;
    [SerializeField] private float spawnTime = 2f;
    public float spawnFrequency = 2f;
    public Transform spawnPoint;

    [SerializeField] private float timeBuble = 8f;

    public float timeBubleFrequency = 8f;
    void Start()
    {
        spawnTime = spawnFrequency;
        timeBuble = timeBubleFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        timeBuble -= Time.deltaTime;


        if (spawnTime <= 0 && timeBuble > 2)
        {
            spawnTime = spawnFrequency;
            Spawn(false);
        }
        else if (timeBuble <= 0)
        {
            timeBuble = timeBubleFrequency;
            Spawn(true);
        }
    }

    public void Spawn(bool isBuble)
    {
        if (isBuble)
        {

            Instantiate(bubbles, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomIndex], spawnPoint.position, Quaternion.identity);
        }
    }


}
