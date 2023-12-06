using UnityEngine;

public class TrunkMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CameraFollow followCamera;

    private void Update()
    {
        if (followCamera.currentPositionX == 410.9f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
    }
}
