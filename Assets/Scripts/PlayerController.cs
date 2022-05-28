using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{

    public Rigidbody2D playerRB;
    private Animator playerAnim;
    public CombatManager combatManager;
    public Transform groundCheckPosition; // Location of object to collide with ground.
    public float groundCheckRadius; // Ground radius.
    public LayerMask groundCheckLayer; // Ground layer.

    private Vector2 input;

    bool facingRight = true; // Checks the facing direction.
    public bool isGrounded = true; // Checks if the player is on the ground.

    [SerializeField] private float moveSpeed; // Speed of player. DEFAULT = 1f
    [SerializeField] private float jumpSpeed; // Jump speed of player. DEFAULT = 1f
    [SerializeField] private float jumpFrequency; // DEFAULT = 1f
    [SerializeField] private float nextJumpTime;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput(); // Function to get horizontal and vertical inputs.
        HorizontalMove(); // Moves the player with inputs from GetInput function.
        FlipFace(); // Flips face by checking facing right 1?0 and speed >? 0.
        Jump(); // Jumps the player if on the ground and vertical input > 0
        OnGroundCheck(); // Checks whether on the ground or not with groundCheckPosition's location.
        Sit();

    }

    void HorizontalMove()
    {
        if(combatManager.playerAlive)
        {
        playerRB.velocity = new Vector2(input.x * moveSpeed, playerRB.velocity.y);
        playerAnim.SetFloat("PlayerSpeed", Mathf.Abs(input.x * moveSpeed));
        }
    }

    public void GetInput()

    {
        if (combatManager.playerAlive)
        {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    void FlipFace()
    {
        if ((input.x * moveSpeed < 0 && facingRight) || (input.x * moveSpeed > 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
        }
    }

    public void Jump()
    {
        if (input.y > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            playerAnim.SetTrigger("IsGrounded");
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            playerRB.velocity = (new Vector2(playerRB.velocity.x, jumpSpeed));
        }
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
    }

    void Sit()
    {
        if (Input.GetAxis("Sit") == 1)
        {
            playerAnim.SetBool("IsSit", true);
        }
        else
        {
            playerAnim.SetBool("IsSit", false);
        }
    }
}