using UnityEngine;

public class OvenInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private bool playerInRange = false;
    private bool placedPhotoIn = false;
    public string[] turningOvenOn;
    public string[] revealingText;
    public string[] defaultIntro;
    private PlayerInventory inventory;
    public GameObject ovenPuzzlePanel;
    private SpriteRenderer sr;
    public Sprite oven_on;
    public Sprite oven_off;
    public GameObject revealed_text;
    public GameObject[] lust;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (!inventory.hasFoundCookbook)
        {
            dm.StartDialogue(defaultIntro);
        } else
        {
            if (!inventory.gotCorrectTemp)
        {
            ovenPuzzlePanel.SetActive(true);
            if (inventory.gotCorrectTemp)
            {
                ovenPuzzlePanel.SetActive(false);
                Interact();
            }
            return;
        } else
        {
            if (!placedPhotoIn)
            {
               dm.StartDialogue(turningOvenOn); 
               sr.sprite = oven_on;
               placedPhotoIn = true;
               return;
            } else
            {
                dm.StartDialogue(revealingText); 
                sr.sprite = oven_off;
                revealed_text.SetActive(true);
                ActivateLust();
                return;
            }
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
            if (revealed_text) revealed_text.SetActive(false);
        }
    }

    void ActivateLust()
    {
        for (int i = 0; i < lust.Length; i++)
        {
            if (lust[i] != null)
                lust[i].SetActive(true);
        }
    }
}