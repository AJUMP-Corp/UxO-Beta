using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBlink : MonoBehaviour
{
    public float blinkInterval = 1.0f; // Intervalo de piscagem em segundos
    private Text textComponent;
    private bool isTextVisible = true;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            isTextVisible = !isTextVisible;
            textComponent.enabled = isTextVisible;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
