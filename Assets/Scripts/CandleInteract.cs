using UnityEngine;

public class CandleInteract : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] hasCandle;
    private bool playerInRange = false;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        inventory.hasCandle = true;
        inventory.candleLit = false;

        if (inventory.candleLight != null)
        {
            inventory.candleLight.enabled = false;
        }

        dm.StartDialogue(hasCandle);

        gameObject.SetActive(false); // remove candle
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}