using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifeTime;

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void ActivateProjectile(bool isOnigama)
    {
        lifeTime = 0;
        gameObject.SetActive(true);

        if (isOnigama)
        {
            GetComponent<Animator>().SetTrigger("rotate");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag != "Enemy" && collision.tag != "Section")
        {
            gameObject.SetActive(false);
        }
    }
}
