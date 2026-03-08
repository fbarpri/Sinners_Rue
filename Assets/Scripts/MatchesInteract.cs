using UnityEngine;

public class MatchesInteract : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] dialogueBefore;
    public string[] dialogueAfter;
    private bool firstInteractionDone = false;
    private bool playerInRange = false;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (!firstInteractionDone) {
        if (inventory.hasCandle && !inventory.candleLit)
            {
                inventory.candleLit = true;

                if (inventory.candleLight != null)
                {
                    inventory.candleLight.enabled = true;
                }

                dm.StartDialogue(dialogueBefore);
                firstInteractionDone = true;
                gameObject.SetActive(false); 
            }
        } else {
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
}
