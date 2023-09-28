using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] frames; // Array contendo os sprites da animação
    public float framesPerSecond = 10.0f; // Velocidade da animação em quadros por segundo

    private int currentFrame = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("NextFrame", 0, 1 / framesPerSecond);
    }

    void NextFrame()
    {
        currentFrame = (currentFrame + 1) % frames.Length;
        spriteRenderer.sprite = frames[currentFrame];
    }
}
