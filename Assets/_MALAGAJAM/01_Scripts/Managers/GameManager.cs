using System.Collections;
using FMOD;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    [SerializeField] private int breatherCounter = 8;         // breather = respiradero, counter of breathers the user has encountered
    [SerializeField] private float gameOverMenuAnimDuration;
    [SerializeField] private GameObject player;

    private bool isGamePaused;
    private bool isGameOver;

    private void Awake() { gameManagerInstance = this; }

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        SoundManager.SetFloatProperty(EBGMStatus.Normal);   // start with normal game theme
        isGamePaused = false;
        isGameOver = false;
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        SoundManager.StopBGM();
    }

    public void DecrementBreatherCounter()
    {
        breatherCounter--;

        // if (breatherCounter == 0 && !isGamePaused && !isGameOver)
        // {
        //     SceneManager.LoadScene(2);    // trigger end game animation in a different scene
        // }
    }

    public void RestartGame()
    {
        isGamePaused = false;
        isGameOver = false;
        //  SoundTrigger.PlayCustomAudioEvent(ESFXType.BackToTheGame);    
        SoundManager.SetFloatProperty(EBGMStatus.Normal);
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        if (!isGamePaused && !isGameOver)
        {
            // SoundTrigger.PlayCustomAudioEvent(ESFXType.Pause);
            isGamePaused = true;
            StartCoroutine(StopGameAfterMenuAnimation());
            UIManager.uiManagerInstance.ShowPauseMenuUI();
        }
    }

    public void GameOver()
    {
        if (!isGamePaused && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(StopGameAfterMenuAnimation());
            UIManager.uiManagerInstance.ShowGameOverUI();
            SoundManager.StopBGM();

            if (player != null)
            {
                Destroy(player);
            }
        }
    }

    public int GetBreather()
    {
        return breatherCounter;
    }
    private IEnumerator StopGameAfterMenuAnimation()
    {
        yield return new WaitForSeconds(gameOverMenuAnimDuration);   // wait for game over menu to be animated
        Time.timeScale = 0f;                                         // stop all game logic
    }
}