using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer timerInstance;

    [SerializeField] private float totalTime;   // duration of the game scene
    [SerializeField] float timeLeft;
    private bool isTimerActive;

    private void Awake()
    {
        timerInstance = this;
        ResetTimer();
    }

    private void Update() { DecrementTimer(); }

    private void DecrementTimer()
    {
        if (isTimerActive)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft > totalTime / 2) { SoundManager.SetFloatProperty(EBGMStatus.Normal); }
            else { SoundManager.SetFloatProperty(EBGMStatus.Accelerado); }

            if (timeLeft <= 0)
            {
                isTimerActive = false;                         // disable timer
                UIManager.uiManagerInstance.ShowGameOverUI();  // show game over UI
                GameManager.gameManagerInstance.GameOver();    // trigger game over logic
            }
        }
    }

    public void AddTimer(float amountToAdd) { timeLeft += amountToAdd; }

    public void DecreaseTime(float amountToDecrease) { timeLeft -= amountToDecrease; }

    public void ResetTimer()
    {
        isTimerActive = true;    // enable timer
        timeLeft = totalTime;    // initialize timer
    }
}