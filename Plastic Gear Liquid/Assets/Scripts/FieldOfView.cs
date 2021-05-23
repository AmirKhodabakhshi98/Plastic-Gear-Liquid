using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldOfView : MonoBehaviour
{

    public float radius;
    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;

    public Pathfinding.AIDestinationSetter aiDestinationSetter;
    public Pathfinding.AIPath aiPath;
    Vector2 directionToTarget;





    // Start is called before the first frame update
    void Start()
    {


        aiDestinationSetter.enabled = false;
        aiPath.enabled = false;

        canSeePlayer = false;

    }

    void FixedUpdate()
    {
        FieldOfViewCheck();
        if (canSeePlayer)
        {
            RotateTowardsPlayer(); //activate enemy rotate method after he starts chase
        }

    }

    private IEnumerator Reset()
    {
      
        ScoreManager.instance.ChangeHealth(); //damage player     

        yield return new WaitForSeconds(1); //sleep

        StartCoroutine("Reset"); //start over
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.collider.CompareTag("Player")) //if enemy hits player
            {
                if (canSeePlayer) //and can see player aka is actively chasing
                {
     //               HealthManager.instance.ChangeHealth(); //damage player

                    StartCoroutine("Reset");
            }
            else
                {
                EnemyActivate(); // if player bumps into enemy while enemy is sleeping, it should activate
            }   
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }


    //method to make the enemy face the player
    private void RotateTowardsPlayer()
    {
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FieldOfViewCheck()
    {
        //check for player within a radius around enemy.       
        Collider2D rangeChecks = Physics2D.OverlapCircle(transform.position, radius, targetMask);


        //if we found something
        if (rangeChecks != null)
        {
            Transform target = rangeChecks.transform; //save player position

            //direction vector from enemy to player.
            directionToTarget = (rangeChecks.transform.position - transform.position).normalized;


            if (Vector2.Angle(transform.right, directionToTarget) < angle / 2) //angle between enemy facing forward and player
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position); //distance of vector between enemy/player
          
            //    Debug.DrawRay(transform.position, directionToTarget*distanceToTarget , Color.red, 10000.0f);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget);

             //   Debug.Log(hit.transform.gameObject.tag);

                if (hit && hit.transform.CompareTag("Player"))   //if raycast hits something and that collission is w/ playertag aka player
                {
                    EnemyActivate();
                    Console.WriteLine("SEE PLAYER");
                }
            }

        }
                
            }
            private void EnemyActivate()
            {
                    canSeePlayer = true;
                    aiDestinationSetter.enabled = true;
                    aiPath.enabled = true;
            }
        }


