using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private PlayerInputActions inputActions;
    private CharacterController controller;
    private Vector2 moveInput;
    private Transform cam;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        controller = GetComponent<CharacterController>();
        cam = FindObjectOfType<Camera>().transform;
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);
        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = cam.forward * moveInput.y + cam.right * moveInput.x;
            moveDir.y = 0;
            moveDir.Normalize();

            controller.Move(moveDir * moveSpeed * Time.deltaTime);

            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}