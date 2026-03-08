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
        if (inventory.hasCandle)
        {
            inventory.candleLit = true;

            if (inventory.candleLight != null)
            {
                inventory.candleLight.enabled = true;
            }

            dm.StartDialogue(hasMatches);
        }
    }
}
