using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    }

    public void OnNoButtonPressed()     // trigger to quit the game
    {
        Time.timeScale = 1f;                            // resume game for DOTween animations to work
        StartCoroutine(QuitGameAfterAnimation());
        gameOverContainer.transform.DOScale(Vector3.one, panelAnimDuration).SetEase(Ease.OutBack, effectBounceStrength);
    }

    private IEnumerator QuitGameAfterAnimation()
    {
        yield return new WaitForSeconds(panelAnimDuration);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    // exit play mode - quit Unity Editor
#endif
        Application.Quit();                                 // quit application
    }

}