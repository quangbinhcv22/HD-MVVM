using DG.Tweening;
using UnityEngine;

public class TweenColorMaterial : MonoBehaviour
{
    [SerializeField] private Renderer target;

    [SerializeField] [Space] private Color color;
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;

    public void Tween()
    {
        target.material.DOColor(color, duration).SetEase(ease);
    }
}