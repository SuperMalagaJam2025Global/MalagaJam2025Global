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
    [SerializeField] private float panelAnimDuration = 1.5f;
    [SerializeField] private float effectBounceStrength = 1.2f;
    [SerializeField] private GameObject yesButton;              // yes button to restart the level
    [SerializeField] private GameObject noButton;               // no button to quit the game
    private bool restartLevel;

    private void Awake() { uiManagerInstance = this; }

    public void ShowGameOverUI()
    {
        gameOverCanvas.SetActive(true);

        gameOverContainer.transform.localScale = Vector3.zero;

        // Disable buttons temporarily
        Button yesButtonComponent = yesButton.GetComponent<Button>();
        Button noButtonComponent = noButton.GetComponent<Button>();
        if (yesButtonComponent != null) { yesButtonComponent.interactable = false; }
        if (noButtonComponent != null) { noButtonComponent.interactable = false; }

        gameOverContainer.transform.DOScale(Vector3.one, panelAnimDuration).SetEase(Ease.OutBack, effectBounceStrength)
            .OnComplete(() =>   // re-enable buttons
            {
                yesButtonComponent.interactable = true;
                noButtonComponent.interactable = true;
            });
    }

    public void OnYesButtonPressed()     // trigger to restart the level
    {
        Time.timeScale = 1f;
        StartCoroutine(ActionAfterAnimation(true));
        gameOverContainer.transform.DOScale(Vector3.zero, panelAnimDuration).SetEase(Ease.OutBack, effectBounceStrength);
    }

    public void OnNoButtonPressed()     // trigger to return to the main menu
    {
        Time.timeScale = 1f;            // resume game for DOTween animations to work
        StartCoroutine(ActionAfterAnimation(false));
        gameOverContainer.transform.DOScale(Vector3.zero, panelAnimDuration).SetEase(Ease.OutBack, effectBounceStrength);
    }

    private IEnumerator ActionAfterAnimation(bool restartLevel)
    {
        yield return new WaitForSeconds(panelAnimDuration);
        if (restartLevel) { SceneManager.LoadScene(1); }        // restart the level
        else { SceneManager.LoadScene(0); }                     // return to the main menu
    }

}