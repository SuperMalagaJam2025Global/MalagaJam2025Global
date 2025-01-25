using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PompaSpawner : MonoBehaviour
{
    public GameObject toSpawn;
    private GameObject pompaSpawned;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        pompaSpawned = Instantiate(toSpawn);
        pompaSpawned.transform.SetParent(this.gameObject.transform);
        pompaSpawned.transform.localPosition = offset;
    }

    // Update is called once per frame
    void Update()
    {
        //PompaSpawned.transform.localPosition = this.transform.localPosition;
    }
}
