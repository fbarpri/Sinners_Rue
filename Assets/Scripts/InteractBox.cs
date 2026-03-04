using UnityEngine;

public class InteractBox : MonoBehaviour
{
    public GameObject eye;
    public bool condition = false;
    private bool playerInRange = false;

    public MonoBehaviour interactableObj; // script instead of object

    private Interactable interactable;
    private DialogueManager dm;

    void Start()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        if (interactableObj != null)
        {
            interactable = interactableObj as Interactable;
        }

        if (eye)
            eye.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (eye) eye.SetActive(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (eye) eye.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space) && !dm.IsActive())
        {
            if (interactable != null)
            {
            interactable.Interact(); 
            }
        }
    }

}