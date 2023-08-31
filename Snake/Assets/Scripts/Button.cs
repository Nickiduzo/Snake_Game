using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float moveDuration;

    private Transform firstPosition;
    private void Start()
    {
        firstPosition = GetComponent<Transform>();
        ButtonMove();
    }
    private void ButtonMove()
    {
        transform.DOMove(targetPosition.position, moveDuration).SetEase(Ease.OutQuad);
    }
    private void ButtonMoveOut()
    {
        transform.DOMove(firstPosition.position, moveDuration).SetEase(Ease.OutQuad);
    }
}
