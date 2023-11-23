using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float currentPositionX;
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    public void MoveAhead(float newPosition)
    {
        currentPositionX = newPosition;
    }
}
