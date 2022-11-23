using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

  public static bool GamePaused = false;

  public GameObject pauseMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                // fix cursor here so its visible in main menu
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;

                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  // maybe fix timescale 
        GamePaused = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked; // centers the cursor
        Cursor.lockState = CursorLockMode.None;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(0);  // 0 is menu scene
    }

    public void Respawn()
    {
        Resume();
        SceneManager.LoadScene(1);  // 1 is game scene
    }
}
