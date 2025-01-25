using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text CountdownComponent; // Manages the velocity
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private float TimeDuration = 160;
    private static float currentTime = 160; // fallback default value
    private static SpawnManager spawnManager;
    private static bool isGameRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        currentTime = TimeDuration;
        // Assuming when It's loading this manager, start the game.
        if(spawnManager != null)
        {
            spawnManager.SetSpawnStatus(true);
        }
        

        if (!SoundManager.StartBGM()) { Debug.Log("Warning, Music doesn't found"); }

        SoundManager.SetFloatProperty(EBGMStatus.Normal);
        
        

    }

    public static void AddTimer(float additiveTime)
    {
        currentTime += additiveTime;
    }

    public static float GetCurrentTime()
    {
        return currentTime;
    }

    public static void ChangedSize(float relativeSize)
    {

        SoundManager.SetFloatProperty(
            relativeSize >= 60 ?
            EBGMStatus.Normal
            : EBGMStatus.Accelerado);
    }

    // Update is called once per frame
    void Update()
    {
        // Stuff always running
        // TODO/
        if (!isGameRunning) { return; }
        // On Game Logic
        currentTime -= Time.deltaTime;
        // CountdownComponent.text = currentTime.ToString("00:00");
        if (currentTime <= 0)
        {
            GameOver();
        }

        if (!isGameRunning && !gameOverUI.activeSelf)
        {
            gameOverUI.SetActive(true);
            return;
        }
    }

    public static void RestartGame()
    {
        SoundManager.SetFloatProperty(EBGMStatus.Normal);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public static void GameOver()
    {
        SoundManager.StopBGM();
        Debug.Log("Game Over!");
        isGameRunning = false;
        spawnManager.SetSpawnStatus(false);
        // playerController.Disable();
    }
}
