using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer timerInstance;

    [SerializeField] private float playerAirTimer;   // duration of the game scene
    [SerializeField] float timeLeft;
    private bool isTimerActive;
    [SerializeField]
    private GameObject pompa;
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

            if (timeLeft > playerAirTimer / 2) { SoundManager.SetFloatProperty(EBGMStatus.Normal); }
            else { SoundManager.SetFloatProperty(EBGMStatus.Accelerado); }

            if (timeLeft <= 0)
            {
                isTimerActive = false;                         // disable timer
                GameManager.gameManagerInstance.GameOver();    // trigger game over logic
            }
        }
    }

    public void AddTimer(float amountToAdd) { timeLeft += amountToAdd; }

    public void DecreaseTime(float amountToDecrease) { timeLeft -= amountToDecrease; }

    public void ResetTimer()
    {
        isTimerActive = true;    // enable timer
        timeLeft = playerAirTimer;    // initialize timer
        // pompa.GetComponent<BubbleAnimation>().ResetBubble();
    }
}