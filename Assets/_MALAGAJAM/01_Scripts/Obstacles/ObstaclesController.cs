using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] obstacles;

    [Header("Obstacles")]
    [SerializeField] private float spawnTime = 2f;
    public float spawnFrequency = 2f;
    public Transform spawnPoint;
    [Header("Bubbles")]
    public GameObject bubbles;
    [SerializeField] private float timeBuble = 8f;

    public float timeBubleFrequency = 8f;

    [Header("Fish")]

    public GameObject fish;
    public float fishFrequency = 10f;
    public float fishTime = 10f;

    [Header("EndGame")]
    public GameObject endGame;
    public bool isEndGame = false;
    public bool endGameActive = false;

    void Start()
    {
        spawnTime = spawnFrequency;
        timeBuble = timeBubleFrequency;
        SpawnObstacle();
        isEndGame = false;
        endGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        int breatherCounter = GameManager.gameManagerInstance.GetBreather();



        if (breatherCounter == 0)
        {
            isEndGame = true;
        }

        if (isEndGame)
        {

            if (!endGameActive)
            {
                endGameActive = true;
                Instantiate(endGame, spawnPoint.position, Quaternion.identity);
            }
        }
        else
        {

            spawnTime -= Time.deltaTime;
            timeBuble -= Time.deltaTime;
            fishTime -= Time.deltaTime;

            if (spawnTime <= 0 && timeBuble > 2)
            {
                spawnTime = spawnFrequency;
                Spawn(false);
            }


            if (timeBuble <= 0)
            {
                timeBuble = timeBubleFrequency;
                Spawn(true);
            }


            if (fishTime <= 0)
            {
                fishTime = fishFrequency;
                Instantiate(fish, spawnPoint.position, Quaternion.identity);
            }

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
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomIndex], spawnPoint.position, Quaternion.identity);
    }


}
