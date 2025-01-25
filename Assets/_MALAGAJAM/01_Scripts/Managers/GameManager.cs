using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text CountdownComponent;
    const float velocity = 1.20f;
    public int sceneState = 0; // Manages the velocity
    public GameObject gameOverUI;
    public GameObject playerCharacter;
    private float currentTime = 60;
    private SoundManager soundManager;

    public float GetVelocity()
    {
        return velocity * sceneState;
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        var basic = playerCharacter.GetComponent<BasicPlayerStates>();

        basic.OnGameOverSignal.AddListener(GameOver);
        basic.OnChangeSize.AddListener(ChangedSize);
        basic.OnAddToTimer.AddListener(ChangedTimer);
    }

    private void ChangedTimer(float arg0)
    {
        currentTime += arg0;
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
        // playerController.Disable();
        gameOverUI.SetActive(true);
    }
}
