using UnityEngine;

public class DrawerInteract : MonoBehaviour, Interactable
{
    public Sprite openedDrawer;
    public GameObject closed_mail;
    public string[] dialogueNoKeyFirst;
    public string[] dialogueKeyFirst;
    public string[] dialogueBeforeNotice;
    public string[] dialogueAfterNotice;

    private bool hasInteractedWhileLocked = false;
    private bool hasOpenedDrawer = false;
    private bool hasNoticedInside = false;
    private SpriteRenderer sr;
    private DialogueManager dm;
    private bool playerInRange = false;
    private PlayerInventory inventory;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    
    public void Interact()
    {
        Debug.Log(
    "Drawer State → " +
    "hasOpenedDrawer: " + hasOpenedDrawer +
    " | hasNoticedInside: " + hasNoticedInside +
    " | hasInteractedWhileLocked: " + hasInteractedWhileLocked +
    " | hasKey: " + (inventory != null && inventory.hasKey)
);

        if (!dm) return;

        // 🔒 Drawer still locked
        if (!hasOpenedDrawer)
        {
            if (!inventory.hasKey)
            {
                // Player tries without key
                dm.StartDialogue(dialogueNoKeyFirst);
                hasInteractedWhileLocked = true;
                return;
            }

            // Player has key
            if (!hasInteractedWhileLocked)
            {
                // Path 2: Had key before ever touching drawer
                dm.StartDialogue(dialogueBeforeNotice);
            }
            else
            {
                // Path 1: Came back with key after trying before
                dm.StartDialogue(dialogueKeyFirst);
            }

            sr.sprite = openedDrawer;
            hasOpenedDrawer = true;
            return;
        }

        // 👀 Drawer open, notices something
        if (!hasNoticedInside)
        {
            dm.StartDialogue(dialogueBeforeNotice);
            hasNoticedInside = true;
            return;
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (closed_mail) closed_mail.SetActive(false);
        }
    }
}