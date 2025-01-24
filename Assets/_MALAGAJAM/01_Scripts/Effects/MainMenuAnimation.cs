using UnityEngine;
using DG.Tweening;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private float fadeInAnimDuration = 1.5f;
    [SerializeField] private float fadeInBounceStrength = 1.2f;
    [SerializeField] private float fadeOutBounceDuration = 0.2f;
    [SerializeField] private float fadeOutAnimDuration = 1.5f;

    private void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
        gameObject.transform.DOScale(Vector3.one, fadeInAnimDuration).SetEase(Ease.OutBack, fadeInBounceStrength);
    }

    public void FadeOutMenuAnimation()
    {
        gameObject.transform.DOScale(Vector3.one * 0.8f, fadeOutBounceDuration).SetEase(Ease.InQuad)
            .OnComplete(() =>
            {
                gameObject.transform.DOScale(Vector3.zero, fadeOutAnimDuration).SetEase(Ease.InBack)
                    .OnComplete(() => { gameObject.SetActive(false); });    // disable main menu
            });
    }
}