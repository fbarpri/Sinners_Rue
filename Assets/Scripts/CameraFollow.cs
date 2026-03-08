using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;
    public float moveSpeed = 5f;
    public float yOffset = 2f;

    private bool snapNextFrame = false; // i used this for moving through doors

    void LateUpdate()
    {
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        float targetY = player.position.y + yOffset;

        Vector3 targetPos = new Vector3(clampedX, targetY, -10f);

        if (snapNextFrame) // no smooth transition
        {
            transform.position = targetPos;
            snapNextFrame = false;
        }
        else
        {
            // smoothed
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    public void SnapToPlayer()
    {
        snapNextFrame = true;
    }
}