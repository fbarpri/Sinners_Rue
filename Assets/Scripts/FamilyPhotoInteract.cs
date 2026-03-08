using UnityEngine;

public class FamilyPhotoInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public GameObject[] wrath;
    public string[] noScissorsInitial;
    public string[] hasScissorsInitial;
    public string[] final;
    private bool initial = true;
    public GameObject ripHusband;
    public Sprite cutout_photo;
    private SpriteRenderer sr;
    public AudioSource audioSource;
    public AudioClip textAppears;
    public AudioClip interactSound;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        audioSource.PlayOneShot(interactSound);
        if (!inventory.hasScissors)
        {
            dm.StartDialogue (noScissorsInitial);
            initial = false;
        } else
        {
            if (initial)
            {
                dm.StartDialogue (hasScissorsInitial);
                initial = false;
            } else
            {
                dm.StartDialogue (final);
                sr.sprite = cutout_photo;
                ripHusband.SetActive (true);
                ActivateWrath();
                audioSource.PlayOneShot(textAppears);
                inventory.wrath = true;
            }
        }
    }

    void ActivateWrath()
    {
        for (int i = 0; i < wrath.Length; i++)
        {
            if (wrath[i] != null)
                wrath[i].SetActive(true);
        }
    }

        protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ripHusband) ripHusband.SetActive(false);
        }
    }
}