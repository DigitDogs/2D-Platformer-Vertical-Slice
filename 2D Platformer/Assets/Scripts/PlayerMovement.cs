using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed, jumpcount;

    [SerializeField]
    private float horizontalMove = 0f;

    private Rigidbody2D rb;

    private void Start()
    {
        // Searches and attatches the rigidbody2d to rb
        if (this.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            rb = this.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (horizontalMove == -1f)
        {

        }
        else if (horizontalMove == 1)
        {

        }

        if (Input.GetButtonDown("Jump"))
        {

        }
    }
}
