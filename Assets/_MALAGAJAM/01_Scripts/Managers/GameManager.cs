using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    [SerializeField] private int breatherCounter = 8;         // breather = respiradero, counter of breathers the user has encountered
    [SerializeField] private float gameOverMenuAnimDuration;
    private bool isGameRunning = true;

    // [SerializeField] private TMPro.TMP_Text CountdownComponent; // Manages the velocity

    private void Awake() { gameManagerInstance = this; }

    private void Start()
    {
        isGameRunning = true;
        if (!SoundManager.StartBGM(BGMType.MainGame)) { Debug.Log("Warning, Music doesn't found"); }
        SoundManager.SetFloatProperty(EBGMStatus.Normal);   // start with normal game theme
    }

    public void DecrementBreatherCounter()
    {
        breatherCounter--;

        if (breatherCounter == 0)
        {
            // Trigger end-game logic - win the game!
        }
    }

    public void RestartGame()
    {
        SoundManager.SetFloatProperty(EBGMStatus.Normal);
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        StartCoroutine(StopGameAfterMenuAnimation());     
        SoundManager.StopBGM();
        isGameRunning = false;
    }

    private IEnumerator StopGameAfterMenuAnimation()
    {
        yield return new WaitForSeconds(gameOverMenuAnimDuration);   // wait for game over menu to be animated
        Time.timeScale = 0f;                                         // stop all game logic
    }
}