using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;

    private float moveSpeed = 1000;
    private float maxSpeed = 5.0f;
    private float jumpForce = 500.0f;

    private float currentNormalSpeed => Mathf.Abs(rb.linearVelocityX / maxSpeed);

    private bool isFlipping = false;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        AddMoveForce();
        UpdateAnimatorParameters();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void Move(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void AddMoveForce()
    {
        if (rb.linearVelocity.magnitude >= maxSpeed)
            return;

        rb.AddForce(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (!isGrounded)
            return;

        rb.AddForce(Vector2.up * jumpForce);
        animator.SetTrigger("Jump");
    }

    private void UpdateAnimatorParameters()
    {
        animator.SetFloat("Speed", currentNormalSpeed);

        animator.SetFloat("Y Velocity", rb.linearVelocityY);

        if (!isFlipping && spriteRenderer.flipX && rb.linearVelocityX > 0.05)
        {
            animator.SetTrigger("Flipping");
            isFlipping = true;
        }

        else if (!isFlipping && !spriteRenderer.flipX && rb.linearVelocityX < -0.05)
        {
            animator.SetTrigger("Flipping");
            isFlipping = true;
        }
    }

    public void FlipX()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        isFlipping = false;
    }
}
