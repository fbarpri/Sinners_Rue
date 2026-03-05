using UnityEngine;

public class MouseBlock : MonoBehaviour
{
    private DialogueManager dm;
    private PlayerInventory inventory;
    public string[] collideMouse;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.windowOpenable = true;
            dm.StartDialogue(collideMouse);
        }
        if (other.CompareTag("Cat"))
        {
            gameObject.SetActive(false);
        }
    }
}
