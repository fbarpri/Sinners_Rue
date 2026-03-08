using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed;
    public float followDistance;

    private Animator anim;
    private SpriteRenderer sr;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
{
    float distX = transform.position.x - player.position.x; // signed distance

    if (Mathf.Abs(distX) > followDistance)
    {
        float targetX;
        if (distX > 0)
        {
            targetX = player.position.x + followDistance;
        }
        else
        {
            targetX = player.position.x - followDistance;
        }
        float step = followSpeed * Time.deltaTime;
        float newX = Mathf.MoveTowards(transform.position.x, targetX, step);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        anim.SetBool("isMoving", true);

        // flip sprite
        if (newX < player.position.x) sr.flipX = false;
        else sr.flipX = true;
    }
    else
    {
        anim.SetBool("isMoving", false);
    }
}
}