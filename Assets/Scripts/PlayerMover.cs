using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;

    private float moveSpeed = 1000;
    private float maxSpeed = 5.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        AddMoveForce();
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
}
