using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 18f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * 7f, rb.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(horizontalInput > 0f){
            anim.SetBool("isRunning",true);
        }
        else if(horizontalInput < 0f){
            anim.SetBool("isRunning",false);
        }
        else{
            anim.SetBool("isRunning",false);
        }

    }
}