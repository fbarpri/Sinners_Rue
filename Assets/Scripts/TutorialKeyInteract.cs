using UnityEngine;

public class TutorialKeyInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public string[] findKey;
    public AudioSource audioSource;
    public AudioClip interactSound;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        dm.StartDialogue(findKey);
        audioSource.PlayOneShot(interactSound);
        inventory.hasTutorialKey = true;
        gameObject.SetActive(false);
    }
}