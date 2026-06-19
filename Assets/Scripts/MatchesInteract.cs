using UnityEngine;

public class MatchesInteract : MonoBehaviour, Interactable
{
    private PlayerInventory inventory;
    private DialogueManager dm;
    public string[] canLightCandle;
    public string[] hasNothing;
    public string[] arson;
    public string[] onlyFurnaceLit;
    public AudioSource audioSource;
    public AudioClip interactSound;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

public void Interact()
{
    inventory.hasMatches = true; // moved here so can turn on furnace without candle
    audioSource.PlayOneShot(interactSound);

    if (inventory.litFurnace && inventory.candleLit) // both things lit
    {
        dm.StartDialogue(arson);
    }
    else if (inventory.hasCandle && !inventory.candleLit) // can light candle
    {
        inventory.candleLit = true;

        if (inventory.candleLight != null)
        {
            inventory.candleLight.enabled = true;
        }

        dm.StartDialogue(canLightCandle);
        gameObject.SetActive(false);
    }
    else if (!inventory.hasCandle && !inventory.litFurnace) // has not found anything
    {
        dm.StartDialogue(hasNothing);
    }
    else // has lit furnace but not found candle
    {
        dm.StartDialogue(onlyFurnaceLit);
    }
}
}
