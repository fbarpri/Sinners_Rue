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
        // move towards player but stop at followDistance
        float targetX = player.position.x + (distX > 0 ? followDistance : -followDistance);
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