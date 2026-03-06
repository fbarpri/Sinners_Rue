using UnityEngine;

public class ClosetInteract : MonoBehaviour, Interactable
{
    public GameObject closed_mail;
    public string[] openingCloset;
    public string[] investigating;
    public string[] gotScissors;
    private DialogueManager dm;
    private bool playerInRange = false;
    private PlayerInventory inventory;
    private bool firstInteraction = true;
    public Sprite open_closet;
    public GameObject opened_mail;
    private SpriteRenderer sr;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (!dm) return;
        if (firstInteraction)
        {
            dm.StartDialogue(openingCloset);
            sr.sprite = open_closet;
            firstInteraction = false;
        }
        else
        {
            inventory.hasMail = true;
            closed_mail.SetActive(true);
            if (!inventory.hasScissors)
            {
                dm.StartDialogue(investigating);
            } else {
                closed_mail.SetActive(false);
                opened_mail.SetActive(true);
                dm.StartDialogue(gotScissors);
            }
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
            if (closed_mail) closed_mail.SetActive(false);
            if (opened_mail) opened_mail.SetActive(false);
        }
    }
}