using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContainer;
    [SerializeField] private GameObject controlsMenuContainer;
    [SerializeField] private GameObject controlsCanvas;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private float controlPanelAnimDuration = 1.5f;
    [SerializeField] private float fadeOutAnimDuration;
    [SerializeField] private float effectBounceStrength = 1.2f;

    public void OnStartButtonPressed() { StartCoroutine(FadeOutMenuAnimation()); }

    public void OnControlsButtonPressed()
    {
        controlsMenuContainer.transform.localScale = Vector3.zero;

        Button backButtonComponent = backButton.GetComponent<Button>();
        if (backButtonComponent != null) { backButtonComponent.interactable = false; }  // disable back button temporarily

        controlsMenuContainer.transform.DOScale(Vector3.one, controlPanelAnimDuration).SetEase(Ease.OutBack, effectBounceStrength)
            .OnComplete(() => { backButtonComponent.interactable = true; });            // enable back button
    }

    public void OnBackButtonPressed()
    {
        StartCoroutine(RemoveControlsCanvas());
        controlsMenuContainer.transform.DOScale(Vector3.zero, controlPanelAnimDuration).SetEase(Ease.InBack, effectBounceStrength)
            .OnStart(() =>
            {
                Button backButtonComponent = backButton.GetComponent<Button>();                  // make sure the back button can't be pressed while animating
                if (backButtonComponent != null) { backButtonComponent.interactable = false; }
            });
    }

    private IEnumerator RemoveControlsCanvas()
    {
        yield return new WaitForSeconds(controlPanelAnimDuration);
        controlsCanvas.SetActive(false);                             // disable the controls panel
    }

    public void OnQuitButtonPressed() { StartCoroutine(QuitGameAnimation()); }

    private IEnumerator FadeOutMenuAnimation()
    {
        yield return new WaitForSeconds(fadeOutAnimDuration);
        SceneManager.LoadScene(1);     // change to game scene - index 1
    }

    private IEnumerator QuitGameAnimation()
    {
        yield return new WaitForSeconds(fadeOutAnimDuration);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    // exit play mode - quit Unity Editor
#endif
        Application.Quit();                                 // quit application
    }
}