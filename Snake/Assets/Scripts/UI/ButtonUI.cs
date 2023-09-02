using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private FadePanel fadePanel;
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
    public void GoMenu()
    {
        fadePanel.FadeIn();
        Invoke("LoadMenu", 0.5f);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
