using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContainer;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private float fadeOutAnimDuration;

    public void OnStartButtonPressed()
    {
        StartCoroutine(FadeOutMenuAnimation());
        SceneManager.LoadScene(1);     // change to game scene - index 1
    }

    private IEnumerator FadeOutMenuAnimation()
    {
        yield return new WaitForSeconds(fadeOutAnimDuration);
        
    }
}
