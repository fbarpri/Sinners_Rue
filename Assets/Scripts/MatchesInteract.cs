using UnityEngine;

public class MatchesInteract : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] hasMatches;
    private bool playerInRange = false;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (inventory.hasCandle && !inventory.candleLit) {
            inventory.candleLit = true;

            if (inventory.candleLight != null)
            {
                inventory.candleLight.enabled = true;
            }

            inventory.hasMatches = true;
            dm.StartDialogue(hasMatches);
            gameObject.SetActive(false); 
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
