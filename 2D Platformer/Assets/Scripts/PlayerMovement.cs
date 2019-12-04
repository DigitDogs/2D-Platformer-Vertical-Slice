using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed, jumpPower;

    [SerializeField]
    private float horizontalMove = 0f;

    private Rigidbody2D rb;

    private bool isFacingRight, isJumping = false;

    private Animator animator;

    private void Start()
    {
        // Searches and attaches the rigidbody2d to rb
        if (this.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            rb = this.gameObject.GetComponent<Rigidbody2D>();
        }

        // Searches for the animator and attaches it to animator
        if (this.gameObject.GetComponent<Animator>() != null)
        {
            animator = this.gameObject.GetComponent<Animator>();
        }
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        animator.SetBool("IsJumping", isJumping);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        // Sends a raycast under the player to the ground
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position - new Vector3(0,2,0), -Vector2.up, 0.1f);
        bool isGrounded = hit.collider;

        // Checks if the player is grounded and sets isJumping to false if the player is on the ground
        if (isGrounded)
        {
            isJumping = false;
        }

        #region Movement
        // Makes the player move to the left
        if (horizontalMove == -1f)
        {
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);

            if (isFacingRight == false)
            {
                transform.Rotate(0, 180, 0);
                isFacingRight = true;
            }
        }
        // Makes the player move to the right
        else if (horizontalMove == 1)
        {
            rb.velocity = new Vector2(speed * 1, rb.velocity.y);

            if (isFacingRight == true)
            {
                transform.Rotate(0, 180, 0);
                isFacingRight = false;
            }
        }
        // Stops the player's movement when not pushing any button
        else if(horizontalMove == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        #endregion

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    /// <summary>
    /// This function makes the player jump.
    /// </summary>
    private void Jump()
    {
        // Checks if the player is jumping
        if (isJumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower * 10);
            isJumping = true;
        }
    }
}
