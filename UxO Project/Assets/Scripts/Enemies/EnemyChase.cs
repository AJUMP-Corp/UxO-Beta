using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;
    [SerializeField] private string enemyName;
    [SerializeField] private float speed;
    [SerializeField] private float stopDuration;

    private bool movingLeft;
    private float stopTimer;
    private Animator animator;
    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = enemy.localScale;
        animator = GameObject.Find(enemyName).GetComponent<Animator>();
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        animator.SetBool("isMoved", false);

        stopTimer += Time.deltaTime;
        if (stopTimer > stopDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int direction)
    {
        stopTimer = 0;
        animator.SetBool("isMoved", true);
        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * direction, initialScale.y, initialScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
    }
}
