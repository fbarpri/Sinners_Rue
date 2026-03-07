using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
{
    if (PlayerPositionManager.lastPosition != Vector3.zero)
    {
        transform.position = PlayerPositionManager.lastPosition;

        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
        if (camFollow != null)
        {
            camFollow.SnapToPlayer(); // now it snaps both X and Y
        }
    }
}
}