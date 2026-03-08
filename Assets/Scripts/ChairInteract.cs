using UnityEngine;

public class ChairInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public string[] initial;
    public string[] canPush;
    public GameObject chairpushed;


    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (inventory.allSins)
        {
            dm.StartDialogue (canPush);
            chairpushed.SetActive(true);
            gameObject.SetActive(false);
            
        } else
        {
            dm.StartDialogue(initial);
        }
    }
}