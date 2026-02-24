using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private InputAction movementAction;
    private void Awake()
    {
        movementAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement = movementAction.ReadValue<Vector2>();
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
}