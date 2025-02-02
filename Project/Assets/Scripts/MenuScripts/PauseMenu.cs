using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject WinMenu;

    // Update is called once per frame
    void Update()
    {
        if (WinMenu.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

   void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
