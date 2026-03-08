using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float leftX;
    public float rightX;

    private bool movingRight = true;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (movingRight)
        {
            pos.x += moveSpeed * Time.deltaTime;
            if (pos.x >= rightX) movingRight = false;
        }
        else
        {
            pos.x -= moveSpeed * Time.deltaTime;
            if (pos.x <= leftX) movingRight = true;
        }

        transform.position = pos;
        sr.flipX = !movingRight;
    }
}