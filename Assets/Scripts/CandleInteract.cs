using UnityEngine;

public class CandleInteract : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] hasLitCandle;
    public string[] hasUnlitCandle;
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
        inventory.hasCandle = true;
        if (inventory.hasMatches == true)
        {
            inventory.candleLit = true;
            if (inventory.candleLight != null)
            {
                inventory.candleLight.enabled = true;
            }
            dm.StartDialogue(hasLitCandle);
        } else
        {
            inventory.candleLit = false;
            if (inventory.candleLight != null)
        {
            inventory.candleLight.enabled = false;
        }
            dm.StartDialogue(hasUnlitCandle);
        }
        gameObject.SetActive(false);
    }
}