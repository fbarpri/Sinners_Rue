using UnityEngine;

public class FurnaceInteract : MonoBehaviour, Interactable
{
    public string[] noMail;
    public string[] hasMatches;
    public string[] hasMail;
    public string[] burnedMail;
    private bool hasBurnedMail = false;
    private DialogueManager dm;
    private PlayerInventory inventory;
    public GameObject unlitFurnace;
    public GameObject litFurnace;
    public GameObject burnedMailFurnace;
    public GameObject[] envy;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {   
        if (!inventory.hasFamilyPhoto && !inventory.hasMatches)
        {
            dm.StartDialogue(noMail);

        } else if (!inventory.hasFamilyPhoto && inventory.hasMatches) 
            {
                unlitFurnace.SetActive(false);
                litFurnace.SetActive(true);
                dm.StartDialogue(hasMatches);

        } else if (inventory.hasFamilyPhoto && !hasBurnedMail)
            {
                litFurnace.SetActive(false);
                burnedMailFurnace.SetActive(true);
                dm.StartDialogue (hasMail);
                hasBurnedMail = true;
                ActivateEnvy();
                inventory.envy = true;
            } else
            {
                dm.StartDialogue (burnedMail);
            }
            
        }

    void ActivateEnvy() {
        for (int i = 0; i < envy.Length; i++)
        {
            if (envy[i] != null)
                envy[i].SetActive(true);
        }
    }
}