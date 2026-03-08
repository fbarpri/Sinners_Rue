using UnityEngine;

public class DoorInteractBedroom : MonoBehaviour, Interactable
{
    public Transform teleportTarget;

    public void Interact()
    {
        if (teleportTarget == null) return;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = teleportTarget.position;
        }

        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
        if (camFollow != null)
        {
            camFollow.SnapToPlayer();
        }
    }
}