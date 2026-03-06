using UnityEngine;

public class ToolsInteract : MonoBehaviour, Interactable
{
    public GameObject scissors;
    public string[] initial;
    public string[] gotMail;
    public string[] gotPhoto;
    public string[] gotPhotoAndMail;
    private DialogueManager dm;
    private PlayerInventory inventory;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (!dm) return;
        if (!inventory.hasFamilyPhoto & !inventory.hasMail)
        {
            dm.StartDialogue(initial);
            return;
        } else
        {
            scissors.SetActive(false);
            inventory.hasScissors = true;
            if (inventory.hasFamilyPhoto && inventory.hasMail){
                dm.StartDialogue(gotPhotoAndMail);
            }
            if (inventory.hasFamilyPhoto && !inventory.hasMail){
                dm.StartDialogue(gotPhoto);

            }
            if (!inventory.hasFamilyPhoto && inventory.hasMail){
                dm.StartDialogue(gotMail);
            }
            return;
            }
    }
}