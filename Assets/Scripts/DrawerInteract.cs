using UnityEngine;

public class DrawerInteract : MonoBehaviour, Interactable
{
    public Sprite openedDrawer;
    public GameObject closed_mail;
    public string[] initialNoKey;
    public string[] secondHasKey;
    public string[] initialHasKey;
    public string[] finalHasKey;

    private bool FirstInteraction = true;
    private bool hasOpenedDrawer = false;
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
        if (!dm) return;

        if (!hasOpenedDrawer) // drawer locked
        {
            if (!inventory.hasKey) // no key
            {
                // [Initial, No Key]
                dm.StartDialogue(initialNoKey);
                FirstInteraction = false;
                return;
            } else // has key
            {
                if (FirstInteraction) // [First, Has Key]
                {
                    dm.StartDialogue(initialHasKey);
                    FirstInteraction = false;
                    sr.sprite = openedDrawer;
                    hasOpenedDrawer = true;
                    return;
                } else // [Second, Has Key]
                {
                    dm.StartDialogue(secondHasKey);
                    FirstInteraction = false;
                    sr.sprite = openedDrawer;
                    hasOpenedDrawer = true;
                    return;
                }
            } 
        } else
        {
            dm.StartDialogue(finalHasKey);
            closed_mail.SetActive(true);
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