using UnityEngine;

public class PetalController : MonoBehaviour
{
    public GameObject petalPrefab; // O sprite da pétala
    public Transform treePosition; // A posição da árvore

    public float petalSpeed = 5f; // A velocidade de queda das pétalas
    public float spawnCooldown = 1f; // O intervalo entre a criação de pétalas

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Atualiza o temporizador
        timeSinceLastSpawn += Time.deltaTime;

        // Verifica se o cooldown foi atingido
        if (timeSinceLastSpawn >= spawnCooldown)
        {
            SpawnPetal();
            timeSinceLastSpawn = 0f; // Reseta o temporizador
        }
    }

    void SpawnPetal()
    {
        Vector3 spawnPosition = new Vector3(treePosition.position.x, treePosition.position.y + 2f, 0f);
        GameObject petal = Instantiate(petalPrefab, spawnPosition, Quaternion.identity);

        // Adiciona um componente Rigidbody2D para controlar a queda
        Rigidbody2D rb2d = petal.AddComponent<Rigidbody2D>();
        rb2d.gravityScale = 1f;

        // Configura a velocidade de queda
        rb2d.velocity = new Vector2(0f, -petalSpeed);

        // Destrói a pétala após atingir uma certa posição (ajuste conforme necessário)
        Destroy(petal, 2.8f);
    }
}
