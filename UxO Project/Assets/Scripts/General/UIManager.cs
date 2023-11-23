using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy)
            {
                PauseGame(false);
                GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().volume = 0.5f;
            }
            else
            {
                PauseGame(true);
                GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().volume = 0.1f;
            }
        }
    }

    public void PauseGame(bool status)
    {
        pauseMenu.SetActive(status);

        if (status)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        PauseGame(false);
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().volume = 0.5f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
