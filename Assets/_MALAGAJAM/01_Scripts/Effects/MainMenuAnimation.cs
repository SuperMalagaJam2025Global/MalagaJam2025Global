using UnityEngine;
using DG.Tweening;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private float fadeAnimDuration = 1.5f;
    [SerializeField] private float effectBounceStrength = 1.2f;

    private void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
        gameObject.transform.DOScale(Vector3.one, fadeAnimDuration).SetEase(Ease.OutBack, effectBounceStrength);
    }

    public void FadeOutMenuAnimation()
    {
        gameObject.transform.DOScale(Vector3.zero, fadeAnimDuration).SetEase(Ease.InBack, effectBounceStrength)
            .OnComplete(() => { gameObject.SetActive(false); });     // disable main menu
    }
}