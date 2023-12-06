using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Health playerHealth;
    private Stamina playerStamina;

    [SerializeField] private float posX;
    [SerializeField] private float cameraPosX;
    [SerializeField] private CameraFollow followCamera;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        playerStamina = GetComponent<Stamina>();
    }

    public void Respawn()
    {
        transform.position = new Vector2(posX, 0);
        playerHealth.ResetHealth();
        playerStamina.ResetStamina();
        followCamera.MoveAhead(cameraPosX);
    }
}
