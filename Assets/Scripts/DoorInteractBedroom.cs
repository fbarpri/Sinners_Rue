using UnityEngine;

public class DoorInteractBedroom : MonoBehaviour, Interactable
{
    public Transform teleportTarget; // where the player should appear

    public void Interact()
    {
        if (teleportTarget == null) return;

        // Move player to target
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = teleportTarget.position;
        }

        // Snap camera to player
        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
        if (camFollow != null)
        {
            camFollow.SnapToPlayer();
        }
    }
}