using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    [SerializeField] private float duration;
    public event Action FadingIn;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = true;
        FadeOut();
    }
    
    public Tween FadeOut()
    {
        image.DOFade(1f, 0f);
        return image.DOFade(0f, duration * 1.5f).SetEase(Ease.InOutQuad).SetLink(image.gameObject).OnComplete((() => image.enabled = false));
    }
    public Tween FadeIn()
    {
        FadingIn?.Invoke();
        image.enabled = true;
        return image.DOFade(1f, duration).SetLink(image.gameObject);
    }
    private void StartFadeIn() => FadeIn();
}
