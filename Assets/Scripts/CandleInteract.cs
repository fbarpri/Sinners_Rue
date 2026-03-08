using UnityEngine;

public class CandleInteract : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] hasCandle;
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
        inventory.candleLit = false;

        if (inventory.candleLight != null)
        {
            inventory.candleLight.enabled = false;
        }

        dm.StartDialogue(hasCandle);

        gameObject.SetActive(false); // remove candle
    }
}