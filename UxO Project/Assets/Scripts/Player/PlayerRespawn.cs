using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Health playerHealth;
    private Stamina playerStamina;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        playerStamina = GetComponent<Stamina>();
    }

    public void Respawn()
    {
        transform.position = new Vector2(-14.5f, 0);
        playerHealth.ResetHealth();
        playerStamina.ResetStamina();
    }
}
