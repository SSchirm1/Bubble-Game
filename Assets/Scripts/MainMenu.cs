using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool firstTime = true;
    
    public void PlayGame()
    {
        Debug.Log(firstTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + (firstTime ? 1 : 2));
    }
    
    public void viewTutorial() {
      firstTime = false;
    }
}
