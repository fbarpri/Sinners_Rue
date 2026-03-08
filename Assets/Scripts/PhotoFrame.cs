using UnityEngine;

public class PhotoFrame : MonoBehaviour, Interactable
{
    public Sprite photoFramePeeking;
    public GameObject zoomedPhoto;
    public string[] dialogueBefore;
    public string[] dialogueAfter;

    private bool firstInteractionDone = false;
    private SpriteRenderer sr;
    private DialogueManager dm;
    public AudioSource audioSource;
    public AudioClip interactSound;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        dm = FindFirstObjectByType<DialogueManager>();
        if (zoomedPhoto) zoomedPhoto.SetActive(false);
    }

    public void Interact()
    {
        if (!dm) return;
        audioSource.PlayOneShot(interactSound);
        if (!firstInteractionDone)
        {
            dm.StartDialogue(dialogueBefore);
            sr.sprite = photoFramePeeking;  // appears after first dialogue
            firstInteractionDone = true;
        }
        else
        {
            if (zoomedPhoto) zoomedPhoto.SetActive(true);
            dm.StartDialogue(dialogueAfter);
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoomedPhoto) zoomedPhoto.SetActive(false);
        }
    }
}