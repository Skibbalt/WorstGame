using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private bool isFacingRight = true;
    public static event System.Action OnJump; // Event for when the player jumps

    public int totalOrbsCollected; //Siena added this because this value has to change when clicking a "gacha button". Don't remove.
    //Siena: I made this because in "GatchaBall" script, the int value is static and isn't flexible to change if we minus or add onto that value from another script.
    //Siena: I made another int that wasn't static in "GatchaBall" script to simply have the same value, but it didn't work as I wanted. They only increase once, then destroy themselves.
    //Siena: That causes an issue, which lead me to make this int in player.
    //Siena: Because that int is static as well, the texts that are attached to "GatchaBall" script don't change if I adjust the value from another script

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float airControlFactor = 0.5f; // Friction factor for air control
    [SerializeField] private float groundDeceleration = 10f; // Deceleration when stopping on the ground

    private bool isGrounded;

    void Update()
    {
        isGrounded = IsGrounded();
        HandleMovement();
        FlipCharacter();
    }

    private void HandleMovement()
    {
        if (isGrounded)
        {
            // Grounded movement
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if (horizontal == 0 && Mathf.Abs(rb.velocity.x) > 0)
            {
                // Apply deceleration when stopping
                rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, 0, groundDeceleration * Time.deltaTime), rb.velocity.y);
            }
        }
        else
        {
            // Air control
            rb.velocity = new Vector2(horizontal * speed * airControlFactor, rb.velocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            OnJump?.Invoke(); // Trigger the OnJump event
        }
        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipCharacter()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

}
