using UnityEngine;

public class WineGlassInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public string[] finalDialogue;


    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        inventory.hasWine = true;
        dm.StartDialogue (finalDialogue);

    }
}