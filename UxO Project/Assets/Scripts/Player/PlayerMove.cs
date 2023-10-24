using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private bool isJumping = false;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;

    private bool isDashing = false;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;

    // Awake is called when the script instance is loaded
    private void Awake()
    {
        // Initializes body and animator from player
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Implements dash
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Dash());
        }

        // Implements jump (basic)
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // Activates the player's walking animation
        animator.SetBool("isWalking", horizontalInput != 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Resets jump state when colliding with something (player is on the ground)
        isJumping = false;
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * dashSpeed, body.velocity.y);
        animator.SetTrigger("isDashing");
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}
