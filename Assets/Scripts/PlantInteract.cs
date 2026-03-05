using UnityEngine;

public class PlantInteract : MonoBehaviour, Interactable
{
    public GameObject key;
    public string[] dialogueBefore;
    public string[] dialogueAfter;

    private bool firstInteractionDone = false;
    private DialogueManager dm;
    private bool playerInRange = false;
    private PlayerInventory inventory;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (!dm) return;
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

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (firstInteractionDone) key.SetActive(false);
        }
    }
}