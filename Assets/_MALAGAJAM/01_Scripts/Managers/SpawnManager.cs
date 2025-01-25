using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    //public GameObject PrefabToSpawn;

    public float startDelay = 2, repeatRate = 2;

    [SerializeField] private bool BackgroundMode;

    [SerializeField] private float minY = 3;
    [SerializeField] private float maxY = 4;

    private float enemiesSpawned, enemiesToSpawn;

    [SerializeField] List<GameObject> SpawnTypes;

//    [SerializeField] List<int> LocationSpawns = new List<int>(){-4,};

    [SerializeField] private float SpawnRange = 20f;

    protected UnityEvent WaveEndedSignal = new UnityEvent();

    public UnityEvent OnWaveEndedSignal { get { return WaveEndedSignal; } }


    bool IsActive;

    private float[] tmp = new float[2];

    private List<GameObject> lastSpawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnObstacule", startDelay, repeatRate);
    }

    void SpawnObstacule()
    {
        if(!IsActive)
        {
            CancelInvoke(nameof(SpawnObstacule));return;
        }

        GameObject PrefabToSpawn = SpawnTypes[Random.Range(0, SpawnTypes.Count)];
        
        if (BackgroundMode)
        {
            tmp[0]= minY;
            tmp[1]= maxY;

            // Choose which side spawn, left or right
            if (Random.Range(0,2) >= 1)
            {
                tmp[0]*=-1;
                tmp[1]*=-1;
                
            }
                Instantiate(PrefabToSpawn, 
                    new Vector3(Random.Range((float)tmp[0], (float)tmp[1]), 0, 40), 
                    PrefabToSpawn.transform.rotation
                    );
            return;
        }

        Instantiate(PrefabToSpawn, 
            new Vector3(Random.Range(-SpawnRange,SpawnRange),0 ,40), 
            PrefabToSpawn.transform.rotation
        );

        enemiesSpawned++;
        if (enemiesSpawned == enemiesToSpawn){ WaveEndedSignal.Invoke();}
    }

    public void SetSpawnStatus(bool status)
    {
        if (status){InvokeRepeating(nameof(SpawnObstacule), startDelay, repeatRate); }
        this.IsActive = status;
    }

    public void SetEnemiesWaves(List<GameObject> test, int values)
    {
        SpawnTypes = test;
        enemiesToSpawn = values;
        enemiesSpawned = 0;
    }
}
