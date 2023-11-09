using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private bool isDead;
    private Animator animator;
    private BoxCollider2D boxCollider;
    [SerializeField] private float startHealth;
    [SerializeField] private float timeToDestroy;
    public float currentHealth { get; private set; }

    // Awake is called when the script instance is loaded
    private void Awake()
    {
        currentHealth = startHealth;
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void PlayerTakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startHealth);
        
        if (currentHealth > 0)
        {
            animator.SetTrigger("isHurting");
        }
        else
        {
            if (!isDead)
            {
                animator.SetTrigger("isDying");
                GetComponent<PlayerMove>().enabled = false;
                boxCollider.size = new Vector2(7, 2);
                isDead = true;
            }
        }
    }

    public void EnemyTakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startHealth);

        if (currentHealth > 0)
        {
            animator.SetTrigger("isHurted");
        }
        else
        {
            if (!isDead)
            {
                animator.SetTrigger("isDied");
                StartCoroutine(DestroyEnemy());
                isDead = true;
            }
        }
    }

    public void ResetHealth()
    {
        isDead = false;
        currentHealth = startHealth;
        boxCollider.size = new Vector2(3, 6);
        GetComponent<PlayerMove>().enabled = true;
        animator.ResetTrigger("isDying");
        animator.Play("PlayerStopped");
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
