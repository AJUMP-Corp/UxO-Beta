using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes body and animator from player
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Implements left-right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Changes the direction of the player's sprite
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Implements jump (basic)
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }

        // Activates the player's walking animation
        animator.SetBool("isWalking", horizontalInput != 0);
    }
}
