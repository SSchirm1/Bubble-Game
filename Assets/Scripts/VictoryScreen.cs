using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
     public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TutorialButton()
    {
      MainMenu.firstTime = false;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
