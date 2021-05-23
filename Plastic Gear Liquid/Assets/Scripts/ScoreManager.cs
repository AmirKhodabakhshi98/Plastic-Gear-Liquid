using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    public int winScore;
    public GameObject restartImage;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString();
        if(score >= winScore)
        {
            restartImage.GetComponent<GameOverScreen>().Setup(score);

        }
    }

   
    public int playerScore()
    {
        return score; 
    }
}
