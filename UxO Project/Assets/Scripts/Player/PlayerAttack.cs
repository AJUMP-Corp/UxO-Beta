using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float attackCooldown;

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
            animator.SetTrigger("isAttacking");
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;
    }
}
