using UnityEngine;

public class SinkInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public GameObject[] greed;
    public string[] luxuryMakeup;
    public string[] allSins;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        dm.StartDialogue (luxuryMakeup);
        ActivateGreed();
        inventory.greed = true;
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