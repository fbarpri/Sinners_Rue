using UnityEngine;

public class WindowInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    public string[] noOpen;
    public string[] yesOpen;
    private PlayerInventory inventory;
    private SpriteRenderer sr;
    public Sprite window_open;
    public GameObject[] sloth;
    private bool playerInRange = false;
    public GameObject whiskers;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (!inventory.windowOpenable)
        {
            dm.StartDialogue(noOpen);
            return;
        } else
        {
            dm.StartDialogue(yesOpen);
            sr.sprite = window_open;
            whiskers.SetActive(true);
            ActivateSloth();
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
        }
    }

    void ActivateSloth()
    {
        for (int i = 0; i < sloth.Length; i++)
        {
            if (sloth[i] != null) sloth[i].SetActive(true);
        }
    }
}