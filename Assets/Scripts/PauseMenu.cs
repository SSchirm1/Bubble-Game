using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

  public static bool GamePaused = false;

  public GameObject pauseMenuUI;
  public GameObject respawnMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                // fix cursor here so its visible in main menu
                DeactivateCursor();
                Resume();
            } else
            {
                Pause();
            }
        }

        /* code for respawn menu, needs life count to work
        if (lives <= 0)
        {
            Respawn();
        }
        */

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.5f;  
        GamePaused = false;
    }

    void Pause()
    {
        ActivateCursor();

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    void Respawn()
    {
        ActivateCursor();
        respawnMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;

    }

    void ActivateCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked; // centers the cursor
        Cursor.lockState = CursorLockMode.None;
    }
    
    void DeactivateCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(0);  // 0 is menu scene
    }

    public void RespawnButton()
    {
        Resume();
        SceneManager.LoadScene(1);  // 1 is game scene
    }


}
