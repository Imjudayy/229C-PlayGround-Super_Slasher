using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public int maxJumps = 2;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector2 inputMove;
    private int jumpCount = 0;
    private bool isGrounded;
    private float gravity = -9.81f;
    private float verticalVelocity;

    private PlayerInput playerInput;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        CheckGround();
        Move();
    }

    private void Move()
    {
        Vector3 move = transform.right * inputMove.x + transform.forward * inputMove.y;
        moveDirection = move * moveSpeed;

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        verticalVelocity += gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && jumpCount < maxJumps)
        {
            verticalVelocity = jumpForce;
            jumpCount++;
        }
    }

    // เปลี่ยน Input ถ้ามีการกดปุ่มจากอุปกรณ์อื่น
    public void OnDeviceLost()
    {
        Debug.Log($"{playerInput.devices} Disconnected");
    }

    public void OnDeviceRegained()
    {
        Debug.Log($"{playerInput.devices} Reconnected");
    }
}
