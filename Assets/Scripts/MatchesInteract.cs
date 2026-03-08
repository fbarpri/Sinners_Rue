using UnityEngine;

public class MatchesInteract : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] hasMatches;
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
        if (inventory.hasCandle && !inventory.candleLit) {
            inventory.candleLit = true;

            if (inventory.candleLight != null)
            {
                inventory.candleLight.enabled = true;
            }

            inventory.hasMatches = true;
            dm.StartDialogue(hasMatches);
            gameObject.SetActive(false); 
        }
    }
}
