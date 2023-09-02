using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPannel : MonoBehaviour
{
    [SerializeField] private FadePanel fadePanel;
    [SerializeField] private TextMeshProUGUI result;

    private void Awake()
    {
        result.text += Score.ReturnScore().ToString();
    }
    public void ExitButtonClick()
    {
        fadePanel.FadeIn();
        Invoke("GoMenu", 0.3f);
    }
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
    private void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
