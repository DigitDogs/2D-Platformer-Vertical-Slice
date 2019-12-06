using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource jumpSound;

    [SerializeField]
    private int speed, jumpPower;

    [SerializeField]
    private float horizontalMove = 0f;

    private Rigidbody2D rb;

    private bool isFacingRight, isJumping = false, isGrounded, hitWallRight, hitWallLeft;

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

        // Searches for the jump audio source in the children
        if (this.gameObject.GetComponentInChildren<AudioSource>() != null)
        {
            jumpSound = this.gameObject.GetComponentInChildren<AudioSource>();
        }
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        // Sets all the variables for the animations
        animator.SetBool("HitWallLeft", hitWallLeft);
        animator.SetBool("HitWallRight", hitWallRight);
        animator.SetBool("IsJumping", isJumping);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        #region Ground check
        // Sends 2 raycasts under the player to the ground to see if the player is gorunded
        RaycastHit2D botRight = Physics2D.Raycast(this.gameObject.transform.position + new Vector3(0.6f, -2f, 0), -Vector2.up, 0.1f);
        bool botRightIsGrounded = botRight.collider;
        RaycastHit2D botLeft = Physics2D.Raycast(this.gameObject.transform.position + new Vector3(-0.6f, -2f, 0), -Vector2.up, 0.1f);
        bool botLeftIsGrounded = botLeft.collider;

        if (botLeftIsGrounded || botRightIsGrounded)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Debug.Log("Is grounded: " + isGrounded);
        
        if (isGrounded)
        {
            isJumping = false;
        }
        #endregion

        #region Wall Detection
        // Sends 2 raycasts to the left and right to detect collision with walls so you stop moving

        RaycastHit2D wallHitTopR = Physics2D.Raycast(this.gameObject.transform.position + new Vector3(1.2f, 0.75f, 0), -Vector2.right, 0.1f);
        bool hitWallRightTop = wallHitTopR.collider;
        RaycastHit2D wallHitMidR = Physics2D.Raycast(this.gameObject.transform.position + new Vector3(1.2f, -1.1f, 0), -Vector2.right, 0.1f);
        bool hitWallRightMid = wallHitMidR.collider;

        if(hitWallRightTop || hitWallRightMid)
        {
            hitWallRight = true;
        }
        else
        {
            hitWallRight = false;
        }

        RaycastHit2D wallHitTopL = Physics2D.Raycast(this.gameObject.transform.position + new Vector3(-1.2f, 0.75f, 0), Vector2.right, 0.1f);
        bool hitWallLeftTop = wallHitTopL.collider;
        RaycastHit2D wallHitMidL = Physics2D.Raycast(this.gameObject.transform.position + new Vector3(-1.2f, -1.1f, 0), Vector2.right, 0.1f);
        bool hitWallLeftMid = wallHitMidL.collider;

        if(hitWallLeftTop || hitWallLeftMid)
        {
            hitWallLeft = true;
        }
        else
        {
            hitWallLeft = false;
        }

        Debug.Log("Hit wall left: " + hitWallLeft);
        Debug.Log("Hit wall right: " + hitWallRight);
        #endregion

        #region Movement
        // Makes the player move to the left
        if (horizontalMove == -1f && hitWallLeft != true)
        {
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);

            if (isFacingRight == false)
            {
                transform.Rotate(0, 180, 0);
                isFacingRight = true;
            }
        }
        // Makes the player move to the right
        else if (horizontalMove == 1 && hitWallRight != true)
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
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;

            jumpSound.Play();
        }
    }
}
