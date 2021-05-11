using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animChange : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
     //   animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("startShoot", true);
        }else animator.SetBool("startShoot", false);

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
           
              animator.SetBool("move", true);
            
        }else animator.SetBool("move", false);
    }

}
