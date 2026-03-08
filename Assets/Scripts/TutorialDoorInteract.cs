using UnityEngine;

public class TutorialDoorInteract : MonoBehaviour, Interactable
{
    public Transform teleportTarget; // where the player should appear
    private DialogueManager dm;
    private PlayerInventory inventory;
    private GameObject player;
    private CameraFollow camFollow;
    public string[] noKey;
    public AudioSource audioSource;
    public AudioClip interactSound;

    void Awake()
    {
        dm = FindFirstObjectByType<DialogueManager>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        player = GameObject.FindWithTag("Player");
        camFollow = Camera.main.GetComponent<CameraFollow>();
    }

    public void Interact()
    {
        audioSource.PlayOneShot(interactSound);
        if (inventory.hasTutorialKey)
        {
            if (teleportTarget == null) return;
            player.transform.position = teleportTarget.position;
            camFollow.SnapToPlayer();
        }
        else
        {
            dm.StartDialogue (noKey);
        }
    }
}