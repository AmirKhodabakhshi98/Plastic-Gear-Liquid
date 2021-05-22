using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 moveDirection;
    public float pushback;

  //  public Animator animator; 


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    //
    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); //hämtar user input
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;


        //rotate player character based on input
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      //      transform.rotation = Quaternion.AngleAxis( 10, Vector3.forward);

        }

    }


    /*
    //push the player back if he hits a zombie. to simulate zombie attacking/pushing the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 playerPosition = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 directionPush = collision.GetContact(0).point - playerPosition;

            directionPush = -directionPush.normalized;

            GetComponent<Rigidbody2D>().AddForce(directionPush * pushback);    
                
                }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject); //destroy collectibles when player collects/touches
        }
        
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); 
      
    }
  
}
