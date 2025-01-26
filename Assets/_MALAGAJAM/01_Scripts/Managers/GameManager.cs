using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    [SerializeField] private int breatherCounter = 8;       // breather = respiradero, counter of breathers the user has encountered
    
    [SerializeField] private float TimeDuration = 160;
    private static float currentTime = 160; // fallback default value
    private static SpawnManager spawnManager;
    private static bool isGameRunning = true;

    // [SerializeField] private TMPro.TMP_Text CountdownComponent; // Manages the velocity

    private void Awake() { gameManagerInstance = this; }

    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        currentTime = TimeDuration;
        // Assuming when It's loading this manager, start the game.
        if(spawnManager != null)
        {
            spawnManager.SetSpawnStatus(true);
        }
        

        if (!SoundManager.StartBGM(BGMType.MainGame)) { Debug.Log("Warning, Music doesn't found"); }

        SoundManager.SetFloatProperty(EBGMStatus.Normal);
        
        

    }

    public void DecrementBreatherCounter()
    {
        breatherCounter--;

        if (breatherCounter == 0)
        {
            // Trigger end-game logic
            
        }

    }

    public static void AddTimer(float additiveTime)
    {
        currentTime += additiveTime;
    }

    public static float GetCurrentTime()
    {
        return currentTime;
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

    public void RestartGame()
    {
        SoundManager.SetFloatProperty(EBGMStatus.Normal);
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SoundManager.StopBGM();
        Debug.Log("Game Over!");
        isGameRunning = false;
        spawnManager.SetSpawnStatus(false);
        // playerController.Disable();
    }
}
