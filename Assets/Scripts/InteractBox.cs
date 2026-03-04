using UnityEngine;

public class InteractBox : MonoBehaviour, Interactable
{
    public GameObject eye;          // drag your manually placed eye here
    public string[] dialogueBefore;  // dialogue when object not yet found
    public string[] dialogueAfter;   // dialogue after puzzle/object found
    public bool hasFoundObject = false;

    private DialogueManager dm;
    private bool playerInRange = false;

    void Start()
    {
        dm = FindFirstObjectByType<DialogueManager>();

        if (eye)
            eye.SetActive(false); // start hidden
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (eye) eye.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (eye) eye.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (!dm) return;

        // choose dialogue based on puzzle progress
        if (hasFoundObject && dialogueAfter.Length > 0)
            dm.StartDialogue(dialogueAfter);
        else
            dm.StartDialogue(dialogueBefore);
    }
}