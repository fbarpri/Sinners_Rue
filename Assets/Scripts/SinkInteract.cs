using UnityEngine;

public class SinkInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public GameObject[] greed;
    public string[] luxuryMakeup;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        dm.StartDialogue (luxuryMakeup);
        ActivateGreed();
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