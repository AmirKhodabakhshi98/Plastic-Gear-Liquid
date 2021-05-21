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




    // Start is called before the first frame update
    void Start()
    {

        //   playerRef = GameObject.FindGameObjectWithTag("Player");


        aiDestinationSetter.enabled = false;
        aiPath.enabled = false;

    }

    void Update()
    {
        FieldOfViewCheck();
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
            Vector2 directionToTarget = (rangeChecks.transform.position - transform.position).normalized;


            if (Vector2.Angle(transform.right, directionToTarget) < angle / 2) //angle between enemy facing forward and player
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position); //distance of vector between enemy/player



          
                Debug.DrawRay(transform.position, directionToTarget*distanceToTarget , Color.red, 10000.0f);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget);

                Debug.Log(hit.transform.gameObject.tag);

                if (hit && hit.transform.CompareTag("Player"))   //if raycast hits something and that collission is w/ playertag aka player
                {
                    canSeePlayer = true;
                    aiDestinationSetter.enabled = true;
                    aiPath.enabled = true;
                    Console.WriteLine("SEE PLAYER");
                }
                else canSeePlayer = false;
            }
            else canSeePlayer = false;
        }
                



                //if enemy could previously see player, but now player moves out of range(thus first if- fails), we want enemy to not see player anymore. i.e player moves out of range.
                //kanske ta bort så fiende alltid följer.
                /*
                else if (canSeePlayer)
                {
                    canSeePlayer = false;
                }
                */


            }

        }
