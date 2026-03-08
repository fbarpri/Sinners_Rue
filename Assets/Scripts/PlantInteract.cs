using UnityEngine;

public class PlantInteract : MonoBehaviour, Interactable
{
    public GameObject key;
    public string[] dialogueBefore;
    public string[] dialogueAfter;

    private bool firstInteractionDone = false;
    private DialogueManager dm;
    private PlayerInventory inventory;
    public AudioSource audioSource;
    public AudioClip interactSound;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (!dm) return;
        audioSource.PlayOneShot(interactSound);
        if (!firstInteractionDone)
        {
            key.SetActive(true);
            dm.StartDialogue(dialogueBefore);
            firstInteractionDone = true;
            inventory.hasKey = true;
        }
        else
        {
            dm.StartDialogue(dialogueAfter);
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (firstInteractionDone) key.SetActive(false);
        }
    }
}