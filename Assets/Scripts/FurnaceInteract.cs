using UnityEngine;

public class FurnaceInteract : MonoBehaviour, Interactable
{
    public string[] noMail;
    public string[] hasMail;
    public string[] burnedMail;
    private bool hasBurnedMail = false;
    private DialogueManager dm;
    private PlayerInventory inventory;
    public GameObject lit_furnace;
    public GameObject[] envy;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (!inventory.hasFamilyPhoto)
        {
            dm.StartDialogue(noMail);
        } else
        {
            if (!hasBurnedMail)
            {
                lit_furnace.SetActive(true);
                dm.StartDialogue (hasMail);
                hasBurnedMail = true;
                ActivateEnvy();
            } else
            {
                dm.StartDialogue (burnedMail);
            }
            
        }
    }
    

    void ActivateEnvy()
    {
        for (int i = 0; i < envy.Length; i++)
        {
            if (envy[i] != null)
                envy[i].SetActive(true);
        }
    }

}
