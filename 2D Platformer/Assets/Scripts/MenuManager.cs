using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    /// <summary>
    /// Placeholder for starting level 1
    /// </summary>
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Used to exit game
    /// </summary>
    public void ExitGameButton()
    {
        Application.Quit();
    }
}
