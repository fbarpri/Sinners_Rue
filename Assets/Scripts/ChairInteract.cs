using UnityEngine;

public class ChairInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public string[] initial;
    public string[] canPush;
    public GameObject chairpushed;
    public AudioSource audioSource;
    public AudioClip interactSound;


    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        audioSource.PlayOneShot(interactSound);
        if (inventory.allSins)
        {
            dm.StartDialogue (canPush);
            chairpushed.SetActive(true);
            gameObject.SetActive(false);
            
        } else
        {
            dm.StartDialogue(initial);
        }
    }
}