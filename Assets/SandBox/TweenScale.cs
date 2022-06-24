using DG.Tweening;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] [Space] private Vector3 endValue;
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;

    public void Tween()
    {
        target.DOScale(endValue, duration).SetEase(ease);
    }
}