using UnityEngine;

public class PompaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Vector3 targetPos;
    private GameObject pompaSpawned;

    private void Start()
    {
        pompaSpawned = Instantiate(objectToSpawn);
        pompaSpawned.transform.SetParent(gameObject.transform);
        pompaSpawned.transform.localPosition = targetPos;
    }
}