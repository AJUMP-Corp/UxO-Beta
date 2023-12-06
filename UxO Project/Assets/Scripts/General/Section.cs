using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] private float section;
    [SerializeField] private float constant;
    [SerializeField] private CameraFollow followCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                section += constant;
                followCamera.MoveAhead(section);
            }
            else if (collision.transform.position.x > transform.position.x)
            {
                section -= constant;
                followCamera.MoveAhead(section);
            }
        }
    }
}
