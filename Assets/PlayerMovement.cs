using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 18f;
    public float rotationSpeed = 100f;
    public Transform groundCheck;
    public float groundCheckRadius = 1.0f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private Camera mainCamera;
    private bool isGrounded;
    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        anim.SetBool("isRunning", horizontalInput != 0);

        if (Input.GetKey(KeyCode.D) && isJumping)
        {
            mainCamera.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && isJumping)
        {
            mainCamera.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
