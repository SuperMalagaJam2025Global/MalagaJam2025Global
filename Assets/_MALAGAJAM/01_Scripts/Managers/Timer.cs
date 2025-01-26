using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer timerInstance;

    [SerializeField] private float totalTime;
    [SerializeField] float timeLeft;
    private bool isTimerActive;

    private void Awake()
    {
        timerInstance = this;
        ResetTimer();
    }

    private void Update()
    {
        DecrementTimer();
    }

    private void DecrementTimer()
    {
        if (isTimerActive)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft > totalTime / 2) { SoundManager.SetFloatProperty(EBGMStatus.Normal); }
            else { SoundManager.SetFloatProperty(EBGMStatus.Accelerado); }

            if (timeLeft < 0)
            {
                isTimerActive = false;                        // disable timer

                GameManager.gameManagerInstance.GameOver();   // trigger game over logic
            }
        }
    }

    public void ResetTimer()
    {
        isTimerActive = true;    // enable timer
        timeLeft = totalTime;    // initialize timer
    }
}