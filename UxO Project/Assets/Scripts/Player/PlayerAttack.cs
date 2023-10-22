using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool hit;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float attackCooldown;

    void Start()
    {
        // Initializes animator and collider from player
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            animator.SetBool("isAttacking", true);
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;
    }

    /* void Attack()
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
    } */
}
