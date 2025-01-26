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
    [SerializeField] private GameObject creditsMenuContainer;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject backControlButton;
    [SerializeField] private GameObject backCreditsButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private float panelAnimDuration = 1.5f;
    [SerializeField] private float fadeOutAnimDuration;
    [SerializeField] private float effectBounceStrength = 1.2f;

    public void OnStartButtonPressed() { StartCoroutine(FadeOutMenuAnimation()); }

    private IEnumerator FadeOutMenuAnimation()
    {
        yield return new WaitForSeconds(fadeOutAnimDuration); 
        SoundTrigger.PlayCustomAudioEvent(ESFXType.BubblesMate);

        SceneManager.LoadScene(1);     // change to game scene - index 1
    }

    public void OnControlsButtonPressed() { OnButtonPress(controlsMenuContainer, backControlButton); }

    public void OnCreditsButtonPressed() { OnButtonPress(creditsMenuContainer, backCreditsButton); }

    private void OnButtonPress(GameObject menuContainer, GameObject button)
    {
        menuContainer.transform.localScale = Vector3.zero;

        Button buttonComponent = button.GetComponent<Button>();
        if (buttonComponent != null) { buttonComponent.interactable = false; }        // disable button temporarily

        menuContainer.transform.DOScale(Vector3.one, panelAnimDuration).SetEase(Ease.OutBack, effectBounceStrength)
            .OnComplete(() => { buttonComponent.interactable = true; });              // re-enable button
    }

    public void OnBackControlsButtonPressed() { SequenceAfterBackButtonIsPressed(controlsCanvas, controlsMenuContainer, backControlButton); }

    public void OnBackCreditsButtonPressed() { SequenceAfterBackButtonIsPressed(creditsCanvas, creditsMenuContainer, backCreditsButton); }

    private void SequenceAfterBackButtonIsPressed(GameObject canvasToRemove, GameObject menuContainer, GameObject backButton)
    {
        StartCoroutine(RemoveCanvas(canvasToRemove));

        menuContainer.transform.DOScale(Vector3.zero, panelAnimDuration).SetEase(Ease.InBack, effectBounceStrength)
            .OnStart(() =>
            {
                Button backButtonComponent = backButton.GetComponent<Button>();                  // make sure the back button can't be pressed while animating
                if (backButtonComponent != null) { backButtonComponent.interactable = false; }
            });
    }

    private IEnumerator RemoveCanvas(GameObject canvasToRemove)
    {
        yield return new WaitForSeconds(panelAnimDuration);
        canvasToRemove.SetActive(false);                         // disable the selected panel (either credits or controls)
    }

    public void OnQuitButtonPressed() { StartCoroutine(QuitGameAnimation()); }

    private IEnumerator QuitGameAnimation()
    {
        yield return new WaitForSeconds(fadeOutAnimDuration);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    // exit play mode - quit Unity Editor
#endif
        Application.Quit();                                 // quit application
    }
}