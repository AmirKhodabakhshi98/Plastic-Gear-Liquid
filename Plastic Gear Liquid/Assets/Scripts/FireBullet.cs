using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation); //spawn bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // get its rigidbody
          rb.AddForce(FirePoint.right * bulletForce, ForceMode2D.Impulse); //makes bullet move instnatly
         //  rb.velocity = new Vector2(1 * bulletForce, 0); alternativ implementring

    }

}
