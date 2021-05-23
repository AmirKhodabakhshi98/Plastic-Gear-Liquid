using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Restart : MonoBehaviour
{
   // public Button btnRestart; 
    
    public void RestartGame()
    {
        //Loading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        resumeGame(); 
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }
}
