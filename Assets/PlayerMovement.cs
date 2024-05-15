using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float horizontal;
    [SerializeField] float speed = 50f;
    [SerializeField] float jumpPower = 16f;
    bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        print("Move Detected");
        horizontal = context.ReadValue<Vector2>().x;
    }
}
 /*   // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x = -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}   
*/