using UnityEngine;

public class SwingTrunk : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float angle;

    private float timer;
    private float currentAngle = 0;

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime * speed;
        float angle = Mathf.Sin(timer) * this.angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + currentAngle));
    }
}
