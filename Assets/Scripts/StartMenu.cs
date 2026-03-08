using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnExitClick()
    {
        Application.Quit();
    // only in unity 
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}