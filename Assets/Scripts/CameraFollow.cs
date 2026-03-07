using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // player to follow
    public float minX, maxX;       // horizontal limits
    public float moveSpeed = 5f;   // smooth follow speed
    public float yOffset = 2f;     // vertical offset above player

    private bool snapNextFrame = false;

    void LateUpdate()
    {
        if (player == null) return;

        // clamp horizontal position
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);

        // vertical position is player's Y plus offset
        float targetY = player.position.y + yOffset;

        Vector3 targetPos = new Vector3(clampedX, targetY, -10f);

        if (snapNextFrame)
        {
            transform.position = targetPos;  // snap instantly
            snapNextFrame = false;
        }
        else
        {
            // smooth follow
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    // Call this to snap camera immediately to player
    public void SnapToPlayer()
    {
        snapNextFrame = true;
    }
}