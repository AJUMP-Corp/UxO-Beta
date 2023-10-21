using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    public Animator animator;

    private bool faceLeft;
    public bool isJumping;
    private bool DoubleJump;

    private bool isAttacking = false;
    public float attackDuration = 1.0f; // A duração do ataque em segundos
    private float attackTimer = 0.0f;

    void Start()
    {
        faceLeft = false;
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        IsWalking();
        Jump();
        FlipCharacter();
        Attack();
        AttackingTime();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontalInput * Speed, rig.velocity.y);
        rig.velocity = velocity;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                animator.SetBool("isJumping", true);
                rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                DoubleJump = true;
            }
            else if (DoubleJump)
            {
                rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                DoubleJump = false;
            }
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    void IsWalking()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                faceLeft = true;
            }
            else
            {
                faceLeft = false;
            }

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void FlipCharacter()
    {
        if (faceLeft)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)       
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetBool("isAttacking", true);
            isAttacking = true;
            attackTimer = 0.0f;
            Speed = 0;
        }
    }

    void AttackingTime()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDuration)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;

                Speed = 10;
            }
        }
    }
}
