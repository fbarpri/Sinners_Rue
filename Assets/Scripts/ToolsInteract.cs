using UnityEngine;

public class ToolsInteract : MonoBehaviour, Interactable
{
    public GameObject scissors;
    public string[] initial;
    public string[] getScissors;
    private DialogueManager dm;
    private PlayerInventory inventory;
    public AudioSource audioSource;
    public AudioClip interactSound;
    private bool finished = false;
    public string[] finishedDialogue;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (!dm) return;
        audioSource.PlayOneShot(interactSound);
        if (finished) {
            dm.StartDialogue(finishedDialogue);
            return;
        } else
        {
        if (inventory.hasMail | inventory.hasFoundBox | inventory.hasFamilyPhoto)
            {
                dm.StartDialogue (getScissors);
                inventory.hasScissors = true;
                scissors.SetActive(false);
                finished = true;
            }
            else
        {
            dm.StartDialogue(initial);
            return;
            } 
        }
    }
}