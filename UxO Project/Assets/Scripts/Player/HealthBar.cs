using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Text HPCount;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called before the first frame update
    private void Start()
    {
        HPCount.text = $"HP: {playerHealth.currentHealth}";
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    private void Update()
    {
        HPCount.text = $"HP: {playerHealth.currentHealth}";
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
