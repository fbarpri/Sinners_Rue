using UnityEngine;

public class CatEntrance : MonoBehaviour
{
    public Transform jumpPoint;
    public Transform kitchenPoint;
    public float moveSpeed;

    private Animator anim;
    private CatFollow follow;
    private int state = 0;            // 0 = jump, 1 = move to kitchen, 2 = follow
    public GameObject mouse1;
    public GameObject mouse2;
    public GameObject kitchenBlock;

    private float groundY;

    void Awake()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<CatFollow>();
        follow.enabled = false; // make sure it's disabled at start
    }

    void Update()
    {
        switch (state)
        {
            case 0: // jump down from window
                MoveJump();
                break;

            case 1: // move to kitchen
                MoveKitchen();
                break;
        }
    }

    void MoveJump()
    {
        if (jumpPoint == null) return;

        // vertical jump first, anything less than this 10 really just looks kinda weird
        transform.position = Vector3.MoveTowards(transform.position, jumpPoint.position, 10 * Time.deltaTime);

        if (Vector2.Distance(transform.position, jumpPoint.position) < 0.05f)
        {
            // lock Y for horizontal movement
            groundY = jumpPoint.position.y;
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, groundY, pos.z);

            state = 1;
        }

        anim.SetBool("isMoving", true);
    }

    void MoveKitchen()
    {
        if (kitchenPoint == null) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.MoveTowards(pos.x, kitchenPoint.position.x, moveSpeed * Time.deltaTime);
        pos.y = groundY;
        transform.position = pos;

        // flip sprite
        Vector3 scale = transform.localScale;
        scale.x = (kitchenPoint.position.x - transform.position.x) > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;

        anim.SetBool("isMoving", true);

        if (Mathf.Abs(transform.position.x - kitchenPoint.position.x) < 0.05f)
        {
            // reached kitchen
            if (mouse1) mouse1.SetActive(false);
            if (mouse2) mouse2.SetActive(false);
            if (kitchenBlock) kitchenBlock.SetActive(false);

            state = 2;
            follow.enabled = true;
            enabled = false; // stop entrance
        }
    }
}