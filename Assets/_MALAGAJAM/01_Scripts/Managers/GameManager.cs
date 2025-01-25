using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text CountdownComponent; // Manages the velocity
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private static float currentTime = 60;
    private SpawnManager spawnManager;
    private bool isGameRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();

        // Assuming when It's loading this manager, start the game.
        spawnManager.SetSpawnStatus(true);

    }

    public static void AddTimer(float additiveTime)
    {
        currentTime += additiveTime;
    }

    public static void ChangedSize(float relativeSize)
    {
        SoundManager.SetFloatProperty(relativeSize);
    }

    // Update is called once per frame
    void Update()
    {
        // Stuff always running
        // TODO/
        if (!isGameRunning) { return; }
        // On Game Logic
        currentTime -= Time.deltaTime;
        CountdownComponent.text = currentTime.ToString("00:00");
        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        isGameRunning = false;
        spawnManager.SetSpawnStatus(false);
        // playerController.Disable();
        gameOverUI.SetActive(true);
    }
}
