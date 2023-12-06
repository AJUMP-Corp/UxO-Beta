using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private float angle;
    [SerializeField] private float rotationSpeed;

    private void Awake()
    {
        leftEdge = transform.position.x - distance;
        rightEdge = transform.position.x + distance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }

        angle += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
