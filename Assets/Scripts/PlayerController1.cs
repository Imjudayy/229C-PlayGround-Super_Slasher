using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public int maxJumps = 2;

    private Rigidbody rb;
    private Vector2 inputMove;
    private int jumpCount = 0;
    private bool isGrounded;
    private bool isHit = false; 

    private PlayerInput playerInput;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    

    private void FixedUpdate()
    {
        CheckGround();
        if (!isHit)
        {
            Move();
        }
    }

    private void Move()
    {
        //Vector3 move = transform.right * inputMove.x + transform.forward * inputMove.y; // ตามแกน Local
        Vector3 move = new Vector3(inputMove.x, 0, inputMove.y);
        Vector3 moveForce = move * moveSpeed;

        rb.AddForce(new Vector3(moveForce.x, 0, moveForce.z), ForceMode.Force);
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
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            isHit = true;
            Invoke("ResetHit", 0.5f); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone")) 
        {
            Debug.Log(gameObject.name + " ตาย! ");
            Destroy(gameObject);
        }
    }

    private void ResetHit()
    {
        isHit = false;
    }
}
