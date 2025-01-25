using UnityEngine;
using DG.Tweening;

public class MenuPlayerAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 firstTargetPos;
    [SerializeField] private Vector3 finalTargetPos;
    [SerializeField] private float enterAnimDuration;
    [SerializeField] private float exitAnimDuration;

    private void Start() { gameObject.transform.DOMove(firstTargetPos, enterAnimDuration).SetEase(Ease.OutSine); }

    public void OnGameStart() { gameObject.transform.DOMove(finalTargetPos, exitAnimDuration); }
}