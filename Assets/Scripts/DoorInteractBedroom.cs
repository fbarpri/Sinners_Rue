using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractBedroom : MonoBehaviour, Interactable
{
    public string sceneToLoad;
    public Vector3 targetPosition; // position in the next scene where player should appear

    public void Interact()
    {
        // save where the player should spawn
        PlayerPositionManager.lastPosition = targetPosition;

        // load the next scene
        SceneManager.LoadScene(sceneToLoad);
    }
}