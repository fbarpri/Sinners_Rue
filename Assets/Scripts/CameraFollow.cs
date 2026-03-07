using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // player pos.
    public float minX, maxX; //prevent from going overboard lol
    public float moveSpeed = 5;

    void LateUpdate() // after player
    {
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        Vector3 new_pos = new Vector3(clampedX, transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, new_pos, moveSpeed * Time.deltaTime); // so its not immediate
    }
}