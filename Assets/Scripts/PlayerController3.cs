using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{

    public Rigidbody2D playerRB;
    SpriteRenderer spriteren;

    public Vector2 movement;
    Animator playerAnim;
    bool facingRight = true;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;
    public bool isGrounded = true;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spriteren = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        HorizontalMove();
        FlipFace();
        Jump();
        OnGroundCheck();

    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(movement.x * moveSpeed, playerRB.velocity.y);
        playerAnim.SetFloat("playerSpeed", Mathf.Abs(movement.x * moveSpeed));

    }

    public void GetInput()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    void FlipFace()
    {
        if ((movement.x * moveSpeed < 0 && facingRight) || (movement.x * moveSpeed > 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
        }
    }

    public void Jump()
    {
        if (movement.y > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            playerRB.velocity = (new Vector2(playerRB.velocity.x, jumpSpeed));
        }
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
    }
}
