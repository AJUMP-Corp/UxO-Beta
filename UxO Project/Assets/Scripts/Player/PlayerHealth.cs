using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isDead;
    private Animator animator;
    private BoxCollider2D boxCollider;
    [SerializeField] private float startHealth;
    public float currentHealth { get; private set; }

    // Awake is called when the script instance is loaded
    private void Awake()
    {
        currentHealth = startHealth;
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startHealth);
        
        if (currentHealth > 0)
        {
            print(currentHealth);
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
}
