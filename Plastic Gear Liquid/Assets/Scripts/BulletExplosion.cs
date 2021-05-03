using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{

    public GameObject explosion;



    void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity); //create explosion, 2nd paramter is explode at current position of bulletlast parameter = no rotation
        Destroy(expl, 0.39f); //when to destroy effects. timer based on animation length
        Destroy(gameObject);

    }

}
