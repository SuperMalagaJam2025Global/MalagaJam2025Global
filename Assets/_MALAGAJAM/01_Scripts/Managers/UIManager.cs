using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManagerInstance;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameOverContainer;
    [SerializeField] private GameObject yesButton;              // yes button to restart the level
    [SerializeField] private GameObject noButton;               // no button to quit the game

    [Header("Pause Menu UI")]
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject pauseMenuContainer;
    [SerializeField] private GameObject pauseMenuButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject quitButton;

    [Header("Animation Settings")]
    [SerializeField] private float panelAnimDuration = 1.5f;
    [SerializeField] private float effectBounceStrength = 1.2f;

    private void Awake() { uiManagerInstance = this; }

    public void ShowGameOverUI()
    {
        gameOverCanvas.SetActive(true);
        OnButtonPress(gameOverContainer, yesButton, noButton);
    }

    public void ShowPauseMenuUI()
    {
        pauseMenuCanvas.SetActive(true);
        OnButtonPress(pauseMenuContainer, resumeButton, quitButton);
    }

    private void OnButtonPress(GameObject menuContainer, GameObject buttonLeft, GameObject buttonRight)
    {
        menuContainer.transform.localScale = Vector3.zero;

        // Disable buttons temporarily
        Button buttonLeftButtonComponent = buttonLeft.GetComponent<Button>();
        Button buttonRightComponent = buttonRight.GetComponent<Button>();
        if (buttonLeftButtonComponent != null) { buttonLeftButtonComponent.interactable = false; }
        if (buttonRightComponent != null) { buttonRightComponent.interactable = false; }

        gameOverContainer.transform.DOScale(Vector3.one, panelAnimDuration).SetEase(Ease.OutBack, effectBounceStrength)
            .OnComplete(() =>   // re-enable buttons
            {
                buttonLeftButtonComponent.interactable = true;
                buttonRightComponent.interactable = true;
            });
    }

    public void OnResumeButtonPressed()
    {

    }

    public void OnYesButtonPressed()     // trigger to restart the level
    {
        Time.timeScale = 1f;
        StartCoroutine(ActionAfterAnimation(true));
        gameOverContainer.transform.DOScale(Vector3.zero, panelAnimDuration).SetEase(Ease.InBack, effectBounceStrength);
    }

    public void OnNoButtonPressed()     // trigger to return to the main menu
    {
        Time.timeScale = 1f;            // resume game for DOTween animations to work
        StartCoroutine(ActionAfterAnimation(false));
        gameOverContainer.transform.DOScale(Vector3.zero, panelAnimDuration).SetEase(Ease.InBack, effectBounceStrength);
    }

    private IEnumerator ActionAfterAnimation(bool restartLevel)
    {
        yield return new WaitForSeconds(panelAnimDuration);
        if (restartLevel) { SceneManager.LoadScene(1); }        // restart the level
        else { SceneManager.LoadScene(0); }                     // return to the main menu
    }

}