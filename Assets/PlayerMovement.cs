using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject shootPrefab;
    [SerializeField] Transform bulletSpawn;

    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] float speed = 50f;
    [SerializeField] float jumpPower = 16f;
    [SerializeField] float shootForce = 10f; // Force for the shoot
    bool isFacingRight = true;
    bool isJumping = false;
    public float thrust = 1.0f;
    // Start is called before the first frame update
    void Start()    
    {

    }
    void Update()
    {
        
        
        if (isJumping && IsGrounded())
        {
            print("jump Detected11");
            rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            //rb.velocity = new Vector2(vertical * speed, rb.velocity.y);
            isJumping = false;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        print("Move Detected");
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("jump Detected");
            isJumping = true;
        }
    }
    bool IsGrounded()
    {
        Collider2D groundCheckCollider = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return groundCheckCollider != null;
    }
    public void Fire(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            GameObject shoot = Instantiate(shootPrefab, bulletSpawn.position, Quaternion.identity);
            Rigidbody2D shootRb = shoot.GetComponent<Rigidbody2D>();
            shootRb.AddForce(new Vector2(shootForce, 0), ForceMode2D.Impulse);
            //shootRb.AddForce(new Vector2(10f,0f));
            
        }
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