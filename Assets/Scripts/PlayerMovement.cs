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
    private void Awake()
    {
        movementAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement = movementAction.ReadValue<Vector2>();
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
}