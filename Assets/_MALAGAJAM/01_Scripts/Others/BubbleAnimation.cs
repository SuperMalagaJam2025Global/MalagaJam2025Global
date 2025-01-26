using UnityEngine;
using DG.Tweening;

public class BubbleAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float bubbleLifetime = 21f;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = gameObject.transform.localScale;
    }

    private void Update()
    {
        gameObject.transform.DOScale(targetScale, bubbleLifetime);
    }

    public void ResetBubble()
    {
        gameObject.transform.DOScale(initialScale, 0.1f);
    }
}
