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
        AnimateBubble(); // Llama a la animación una vez al inicio
    }

    private void AnimateBubble()
    {
        // Inicia la animación hacia el targetScale
        gameObject.transform.DOScale(targetScale, bubbleLifetime);
    }

    public void ResetBubble()
    {
        Debug.Log("ResetBubble");
        // Reinicia la escala al valor inicial y detiene cualquier animación activa


        gameObject.transform.DOKill(); // Detiene cualquier animación activa
        gameObject.transform.localScale = initialScale;
        SoundTrigger.PlayCustomAudioEvent(ESFXType.FillBubble);
        // Opcional: Si deseas reiniciar la animación después del reset
        AnimateBubble();
    }
}