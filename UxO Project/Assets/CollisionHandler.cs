using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject jumpTutorialContainer; // Arraste o objeto "JumpTutorial" para este campo no Inspector.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SetJumpTutorial"))
        {
            // Ative o objeto "JumpTutorial" quando o jogador entrar no gatilho
            jumpTutorialContainer.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SetJumpTutorial"))
        {
            // Desative o objeto "JumpTutorial" quando o jogador sair do gatilho
            jumpTutorialContainer.SetActive(false);
        }
    }
}
