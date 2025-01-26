using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    [SerializeField] private int breatherCounter = 8;         // breather = respiradero, counter of breathers the user has encountered
    [SerializeField] private float gameOverMenuAnimDuration;
    private bool isGamePaused;
    private bool isGameOver;

    private void Awake() { gameManagerInstance = this; }

    private void Start()
    {
        if (!SoundManager.StartBGM(BGMType.MainGame)) { Debug.Log("Warning, Music doesn't found"); }
        SoundManager.SetFloatProperty(EBGMStatus.Normal);   // start with normal game theme
        isGamePaused = false;
        isGameOver = false;
    }

    public void DecrementBreatherCounter()
    {
        breatherCounter--;

        if (breatherCounter == 0 && !isGamePaused && !isGameOver)
        {
            SceneManager.LoadScene(2);    // trigger end game animation in a different scene
        }
    }

    public void RestartGame()
    {
        isGamePaused = false;
        isGameOver = false;
        SoundManager.SetFloatProperty(EBGMStatus.Normal);
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        if(!isGamePaused && !isGameOver)
        {
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
            SoundManager.StopBGM();
        }
    }

    private IEnumerator StopGameAfterMenuAnimation()
    {
        yield return new WaitForSeconds(gameOverMenuAnimDuration);   // wait for game over menu to be animated
        Time.timeScale = 0f;                                         // stop all game logic
    }
}