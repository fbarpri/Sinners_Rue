using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnExitClick()
    {
        Application.Quit();
// only in unity 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}