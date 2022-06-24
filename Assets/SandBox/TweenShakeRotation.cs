using DG.Tweening;
using UnityEngine;

public class TweenShakeRotation : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] [Space] private float duration;
    [SerializeField] private Ease ease;

    public void Tween()
    {
        target.DOShakeRotation(duration).SetEase(ease);
    }
}