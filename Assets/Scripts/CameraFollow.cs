using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;
    public float minY, maxY; // add Y bounds
    public float moveSpeed = 5f;

    private bool snapNextFrame = false;

    void LateUpdate()
    {
        if (player == null) return;

        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(player.position.y, minY, maxY);

        Vector3 targetPos = new Vector3(clampedX, clampedY, -10f);

        if (snapNextFrame)
        {
            transform.position = targetPos;  // snap instantly
            snapNextFrame = false;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    // Call this to snap camera immediately to player
    public void SnapToPlayer()
    {
        snapNextFrame = true;
    }
}