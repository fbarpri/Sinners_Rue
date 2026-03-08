using UnityEngine;

public class TopDrawerInteract : MonoBehaviour, Interactable
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public string[] noPush;
    public string[] getsWine;
    public string[] notAllSinsFound;
    public GameObject chairpushed;
    public GameObject openedDrawer;
    public GameObject[] wine;
    public GameObject[] gluttony;
    public GameObject wineGlass;
    public GameObject wineEye;
    public GameObject candleLit;
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
        if (!inventory.allSins)
        {
            dm.StartDialogue(notAllSinsFound);
        } else
        {
            if (inventory.hasPushedChair)
            {
                inventory.hasCandle = false;
                dm.StartDialogue(getsWine);
                ActivateGluttony();
                ActivateWine();
                audioSource.PlayOneShot(textAppears);
                wineGlass.SetActive(true);
                openedDrawer.SetActive(true);
                candleLit.SetActive (true);
                gameObject.SetActive(false);
            } else
            {
                dm.StartDialogue(noPush);
            }
        }
    }

    void ActivateWine()
    {
        for (int i = 0; i < wine.Length; i++)
        {
            if (wine[i] != null)
                wine[i].SetActive(true);
        }
    }

    void ActivateGluttony()
    {
        for (int i = 0; i < gluttony.Length; i++)
        {
            if (gluttony[i] != null)
                gluttony[i].SetActive(true);
        }
    }
}