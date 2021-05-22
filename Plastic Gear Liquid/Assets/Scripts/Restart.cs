using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Restart : MonoBehaviour
{
      
    
    public void RestartGame()
    {
        //Loading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
