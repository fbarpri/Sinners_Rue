using UnityEngine;

public class BoxInteract : MonoBehaviour, Interactable
{
    public string[] initialHasNothing;
    public string[] openingBox;
    public string[] findingAward;
    private DialogueManager dm;
    private PlayerInventory inventory;
    private bool openedBox = false;
    public GameObject award;
    public GameObject art;
    private SpriteRenderer sr;
    public Sprite openBoxWithStuff;
    public Sprite openBoxEmpty;
    public GameObject[] pride;
    public AudioSource audioSource;
    public AudioClip textAppears;
    public AudioClip interactSound;
    private bool finished = false;
    public string[] finishedDialogue;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        audioSource.PlayOneShot(interactSound);
        if (finished) {
            dm.StartDialogue(finishedDialogue);
            return;
        } else
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
                audioSource.PlayOneShot(textAppears);
                finished = true;
                return;
            }
        }
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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
