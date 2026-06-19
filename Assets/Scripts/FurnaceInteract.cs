using UnityEngine;

public class FurnaceInteract : MonoBehaviour, Interactable
{
    public string[] noMail;
    public string[] canLightFurnace;
    public string[] hasMail;
    public string[] burnedMail;
    public string[] emptyLitFurnace;
    private bool hasBurnedMail = false;
    private DialogueManager dm;
    private PlayerInventory inventory;
    public GameObject firewood;
    public GameObject unlitFurnace;
    public GameObject litFurnace;
    public GameObject burnedMailFurnace;
    public GameObject[] envy;
    public AudioSource audioSource;
    public AudioClip textAppears;
    public AudioClip interactSound;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {   
        audioSource.PlayOneShot(interactSound);
        if (!inventory.hasMail && !inventory.hasMatches)
        {
            dm.StartDialogue(noMail);
        }
        else if (!inventory.hasMail && inventory.hasMatches)
        {
            firewood.SetActive(false);
            unlitFurnace.SetActive(false);
            litFurnace.SetActive(true);
            inventory.litFurnace = true;
            if (!inventory.litFurnace)
            {
                dm.StartDialogue(canLightFurnace); 
            } else
            {
                dm.StartDialogue(emptyLitFurnace);
            }
        }
        else if (inventory.hasMail && inventory.hasMatches && !hasBurnedMail)
        {
            litFurnace.SetActive(false);
            burnedMailFurnace.SetActive(true);

            dm.StartDialogue(hasMail);

            hasBurnedMail = true;
            ActivateEnvy();

            audioSource.PlayOneShot(textAppears);
            inventory.envy = true;
        }
        else
        {
            dm.StartDialogue(burnedMail);
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