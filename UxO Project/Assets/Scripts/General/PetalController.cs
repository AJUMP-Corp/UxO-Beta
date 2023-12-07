using UnityEngine;

public class PetalController : MonoBehaviour
{
    public GameObject petalPrefab; // O sprite da p�tala
    public Transform treePosition; // A posi��o da �rvore

    public float petalSpeed = 5f; // A velocidade de queda das p�talas
    public float spawnCooldown = 1f; // O intervalo entre a cria��o de p�talas

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

        // Destr�i a p�tala ap�s atingir uma certa posi��o (ajuste conforme necess�rio)
        Destroy(petal, 2.8f);
    }
}
