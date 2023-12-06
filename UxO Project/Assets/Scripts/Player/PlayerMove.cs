using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;

    private Stamina playerStamina;
    private BoxCollider2D boxCollider;
    [SerializeField] private float walkSpeed;
    [SerializeField] private LayerMask groundLayer;

    private bool isJumping = false;
    private bool oneMoreJump = false;
    [SerializeField] private float jumpHeight;
    [SerializeField] private AudioClip jumpSound;

    public bool canDash = true;
    private bool isDashing = false;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private AudioClip dashSound;

    // Awake is called when the script instance is loaded
    private void Awake()
    {
        // Initializes body and animator from player
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStamina = GetComponent<Stamina>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Ignores the rest of the code if is dashing
        if (isDashing) return;

        // Implements left-right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * walkSpeed, body.velocity.y);

        // Changes the direction of the player's sprite
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(scaleX, scaleY, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-scaleX, scaleY, 1);
        }

        // Implements dash
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Dash());
            playerStamina.SpendStamina(1);
        }

        // Implements jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                Jump();
                isJumping = true;
                oneMoreJump = true;
            }

            if (isJumping && oneMoreJump)
            {
                Jump();
                oneMoreJump = false;
            }
        }

        // Resets jump state when the player is on the ground
        if (isGrounded())
        {
            isJumping = false;
            oneMoreJump = false;
        }

        // Activates the player's walking animation
        animator.SetBool("isWalking", horizontalInput != 0);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void Jump()
    {
        SoundManager.instance.PlaySound(jumpSound);
        body.velocity = new Vector2(body.velocity.x, body.velocity.y + jumpHeight);
    }

    private IEnumerator Dash()
    {
        if (canDash)
        {
            isDashing = true;
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * dashSpeed, body.velocity.y);
            SoundManager.instance.PlaySound(dashSound);
            animator.SetTrigger("isDashing");
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
        }
    }
}
