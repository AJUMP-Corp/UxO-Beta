using UnityEngine;

public class Katanaji : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;

    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private float checkTimer;

    private Vector3 destination;
    private bool movingOnPlayer;
    private Vector3[] directions = new Vector3[2];

    // transform.localScale = new Vector3(-1, 1, 1);
    private void OnEnable()
    {
        Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        if (movingOnPlayer)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.blue);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !movingOnPlayer)
            {
                movingOnPlayer = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirections()
    {
        directions[0] = -transform.right * range; // Left
        directions[1] = transform.right * range; // Right
    }

    private void Stop()
    {
        destination = transform.position;
        movingOnPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stop();
    }
}
