using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Stamina playerStamina;
    [SerializeField] private Text staminaCount;
    [SerializeField] private Image totalStaminaBar;
    [SerializeField] private Image currentStaminaBar;

    // Start is called before the first frame update
    private void Start()
    {
        staminaCount.text = $"Stamina: {playerStamina.currentStamina}";
        totalStaminaBar.fillAmount = playerStamina.currentStamina / 10;
    }

    // Update is called once per frame
    private void Update()
    {
        staminaCount.text = $"Stamina: {playerStamina.currentStamina}";
        currentStaminaBar.fillAmount = playerStamina.currentStamina / 10;
    }
}
