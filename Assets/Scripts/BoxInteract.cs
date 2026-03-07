using UnityEngine;

public class BoxInteract : MonoBehaviour, Interactable
{
    public string[] initialHasNothing;
    public string[] openingBox;
    public string[] findingAward;
    private DialogueManager dm;
    private PlayerInventory inventory;
    private bool firstEncounter = true;
    private bool openedBox = false;
    public GameObject award;
    public GameObject art;
    private bool playerInRange = false;
    private SpriteRenderer sr;
    public Sprite openBoxWithStuff;
    public Sprite openBoxEmpty;
    public GameObject[] pride;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        inventory.hasFoundBox = true;
        if (!dm) return;
        if (!inventory.hasScissors)
        {
            dm.StartDialogue(initialHasNothing);
            return;
        } else
        {
            if (!openedBox)
            {
                dm.StartDialogue (openingBox);
                art.SetActive(true);
                openedBox = true;
                sr.sprite = openBoxWithStuff;
                return;
            } else
            {
                dm.StartDialogue (findingAward);
                art.SetActive(false);
                sr.sprite = openBoxEmpty;
                award.SetActive(true);
                inventory.pride = true;
                ActivatePride();
                return;
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
            if (art) art.SetActive(false);
        }
    }

    void ActivatePride()
    {
        for (int i = 0; i < pride.Length; i++)
        {
            if (pride[i] != null)
                pride[i].SetActive(true);
        }
    }

}
