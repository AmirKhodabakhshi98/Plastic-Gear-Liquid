using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class HealthManager : MonoBehaviour
{

    public static HealthManager instance;
    public TextMeshProUGUI text;
    int health;
    public int damageValue; //the value by which player hp decreases when hit by a zombie

    

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        health = 100;
    }

    public void FixedUpdate()
    {
        
    }


    public void ChangeHealth()
    {

        health -= damageValue;
        text.text = "health: " + health;
        Debug.Log(health);

    }
}
