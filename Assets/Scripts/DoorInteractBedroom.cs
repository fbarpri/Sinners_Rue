using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractBedroom : MonoBehaviour, Interactable
{
    public string sceneToLoad;
    public string spawnPointName;

    public void Interact()
    {
        SpawnManager.spawnPoint = spawnPointName;
        SceneManager.LoadScene(sceneToLoad);
    }
}