using UnityEngine;
using UnityEngine.Rendering.Universal;
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

        if (inventory.candleLight != null)
        {
            inventory.candleLight.enabled = false;
        }

        dm.StartDialogue(finalDialogue);
    }
}