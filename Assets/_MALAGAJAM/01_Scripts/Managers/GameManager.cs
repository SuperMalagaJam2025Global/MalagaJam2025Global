using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text CountdownComponent;
    const float velocity = 1.20f;
    private int sceneState = 0; // Manages the velocity
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private float currentTime = 60;
    private SoundManager soundManager;
    private SpawnManager spawnManager;

    public float GetVelocity()
    {
        return velocity * sceneState;
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        spawnManager = GetComponent<SpawnManager>();
        var playerStates = playerCharacter.GetComponent<BasicPlayerStates>();

        playerStates.OnGameOverSignal.AddListener(GameOver);
        playerStates.OnChangeSize.AddListener(ChangedSize);
        playerStates.OnAddToTimer.AddListener(ChangedTimer);

        // Assuming when It's loading this manager, start the game.
        spawnManager.SetSpawnStatus(true);

    }

    private void ChangedTimer(float additiveTime)
    {
        currentTime += additiveTime;
    }

    void ChangedSize(float relativeSize)
    {
        soundManager.SetFloatProperty(relativeSize);
    }

    // Update is called once per frame
    void Update()
    {
        // Stuff always running
        // TODO/
        if (sceneState == -1) { return; }
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
        sceneState = -1;
        spawnManager.SetSpawnStatus(false);
        // playerController.Disable();
        gameOverUI.SetActive(true);
    }
}
