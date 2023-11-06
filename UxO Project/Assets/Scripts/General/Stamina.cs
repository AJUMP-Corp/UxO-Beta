using UnityEngine;

public class Stamina : MonoBehaviour
{
    private bool isTired;
    private PlayerMove movement;
    [SerializeField] private float startStamina;
    public float currentStamina { get; private set; }

    // Awake is called when the script instance is loaded
    private void Awake()
    {
        currentStamina = startStamina;
        movement = GetComponent<PlayerMove>();
    }

    public void SpendStamina(float cost)
    {
        currentStamina = Mathf.Clamp(currentStamina - cost, 0, startStamina);

        if (currentStamina > 0)
        {
            // Nothing to do
        }
        else
        {
            if (!isTired)
            {
                movement.canDash = false;
                isTired = true;
            }
        }
    }

    public void ResetStamina()
    {
        isTired = false;
        movement.canDash = true;
        currentStamina = startStamina;
    }
}
