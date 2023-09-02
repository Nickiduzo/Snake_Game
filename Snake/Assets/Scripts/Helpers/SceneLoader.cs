using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private FadePanel panel;
    private int sceneIndex;
    public void PlayButtonClick(int sceneIndex)
    {
        this.sceneIndex = sceneIndex;
        panel.FadeIn();
        Invoke("SceneLoadIndex", 0.3f);
    }
    public void ExitButtonClick()
    {
        panel.FadeIn();
        Invoke("ExitButton", 0.3f);
    }
    private void ExitButton()
    {
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }
    private void SceneLoadIndex() => SceneManager.LoadScene(sceneIndex);
}
