using UnityEngine;
using UnityEngine.SceneManagement;

public class WineGlassInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public string[] finalDialogue;
    public AudioSource audioSource;
    public AudioClip interactSound;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        audioSource.PlayOneShot(interactSound);
        inventory.hasWine = true;
        inventory.endGame = true;
        dm.StartDialogue(finalDialogue);
    }
}