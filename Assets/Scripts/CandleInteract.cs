using UnityEngine;

public class candleLight : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] hasCandle;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        inventory.hasCandle = true;
        inventory.candleLit = true;

        if (inventory.candleLight != null)
        {
            inventory.candleLight.enabled = true;
        }

        dm.StartDialogue(hasCandle);

        gameObject.SetActive(false); // remove candle
    }
}