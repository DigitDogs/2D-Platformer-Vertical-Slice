using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    private void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        // Makes the game pause and activates the pause screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf != true)
            {
                pauseMenu.SetActive(true);

                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);

                Time.timeScale = 1;
            }
        }
    }

    /// <summary>
    /// Resumes the game
    /// </summary>
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1;
    }

    /// <summary>
    /// Placeholder for loading in the main menu
    /// </summary>
    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
