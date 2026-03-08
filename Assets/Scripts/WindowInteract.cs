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
    public GameObject whiskers;
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
            inventory.sloth = true;
            audioSource.PlayOneShot(textAppears);
            finished = true;
        }
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