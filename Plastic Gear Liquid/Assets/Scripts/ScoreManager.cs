using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI coinText;
    int score;
    public int winScore;
    public GameObject restartImage;
    public TextMeshProUGUI healthText;
    int health;
    public int damageValue; //value by which player hp decreases when attacked by zombie



    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        
        health = 100;
        
    }

    //method to alter player heatlh
    public void ChangeHealth()
    {

        health -= damageValue;
        healthText.text = health.ToString();
        Debug.Log(health);

        if(health <= 0)
        {
            restartImage.GetComponent<GameOverScreen>().Setup(score);

        }

    }

    //method to alter player score
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        coinText.text = score.ToString();
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
