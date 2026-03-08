using UnityEngine;

public class SinkInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public GameObject[] greed;
    public string[] luxuryMakeup;
    public AudioSource audioSource;
    public AudioClip textAppears;
    public AudioClip interactSound;
    private bool finished = false;
    public string[] finishedDialogue;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        audioSource.PlayOneShot(interactSound);
        if (finished) {
            dm.StartDialogue(finishedDialogue);
            return;
        } else
        {
            dm.StartDialogue (luxuryMakeup);
            ActivateGreed();
            audioSource.PlayOneShot(textAppears);
            inventory.greed = true;
            finished = true;
        }
    }

    void ActivateGreed()
    {
        for (int i = 0; i < greed.Length; i++)
        {
            if (greed[i] != null)
                greed[i].SetActive(true);
        }
    }
}