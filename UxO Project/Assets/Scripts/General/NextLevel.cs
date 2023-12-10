using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private bool isLevel1;
    [SerializeField] private bool isLevel2;
    [SerializeField] private GameObject transition;

    private void Awake()
    {
        transition.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isLevel1)
            {
                StartCoroutine(LoadLevel("Level2"));
            }
            else if (isLevel2)
            {
                StartCoroutine(LoadLevel("Level3"));
            }
        }
    }

    private IEnumerator LoadLevel(string levelName)
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(10);
        transition.SetActive(false);
        SceneManager.LoadScene(levelName);
    }
}
