using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public float speed;
    public float maxChaseRange;
    public float minChaseRange;

    private Transform target; //the object to be chased, i.e player

    // Start is called before the first frame update
    void Start()
    {
        //sets target to player pos
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy only chases if within range
        if(Vector2.Distance(transform.position, target.position) > minChaseRange &&
            Vector2.Distance(transform.position, target.position) < maxChaseRange) { 

        //move enemy toward player position at input speed. deltaTime makes it not be fps based. 
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
