using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private float attackCooldown;
    [SerializeField] private AudioClip attackSound;

    [SerializeField] private Transform attackPosition;
    [SerializeField] private float attackRange;

    [SerializeField] private float damage;
    [SerializeField] private LayerMask enemyLayer;

    // Awake is called when the script instance is loaded
    private void Awake()
    {
        // Initializes animator from player
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayer);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Health>().EnemyTakeDamage(damage);
            }

            SoundManager.instance.PlaySound(attackSound);
            animator.SetTrigger("isAttacking");
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
