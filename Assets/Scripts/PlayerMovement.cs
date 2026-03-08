using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    private Rigidbody2D rb;
    private Vector2 movement;
    private InputAction movementAction;
    public InputAction interactAction;
    private Interactable currentInteractable; // interactable that player is standing near
    private SpriteRenderer spriteRenderer;
    private Animator _animator;
    private void Awake()
    {
        movementAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        movement = movementAction.ReadValue<Vector2>();
        // true if player is pressing any movement key
        bool moving = movement.x != 0 || movement.y != 0;
        _animator.SetBool("isMoving", moving);
         if (movement.x < 0)
        {
            spriteRenderer.flipX = true;  // face left
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // face right
        }

        if (interactAction.triggered && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    // This function allows outside access to movement direction,
    // for example for animation
    public Vector2 GetMovementDirection()
    {
        return movement;
    }

    private void OnEnable()
    {
        interactAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
    }

    public void SetInteractable(Interactable interactable)
    {
        currentInteractable = interactable;
    }

    public void StopMovement()
    {
        movement = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
        _animator.SetBool("isMoving", false);
    }
}