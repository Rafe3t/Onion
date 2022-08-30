using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.Mathematics;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public CharacterController2D controller2D;
    float move;
    public float Speed = 40f;
    public Animator anim;
    public bool jump = false;
    public bool shoot = false;
    public Rigidbody2D rig;
    public float fallspeed;
    public GameObject bulletPrefab;
    public Transform firepoint;

    // Update is called once per frame
    void Update()
    {

        // moving code
        
        move = Input.GetAxisRaw("Horizontal")*Speed;
        anim.SetFloat("IsMoving", math.abs(move));

        //jump code

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }
        // falling code
        if (Input.GetKey("s"))
        {
            if (rig.velocity.y >= 0.1 | rig.velocity.y <= -0.1)
            {
                rig.gravityScale = 6f;
            }
        }
        else
        {
            rig.gravityScale = 3f;
        }

        // jump and fall animation code

        if (rig.velocity.y < -1.8)
        {
            anim.SetBool("IsJumping", false);

            anim.SetBool("IsFalling", true);
        }
        else
        {
            anim.SetBool("IsFalling", false);
        }

        //shooting code

        if (Input.GetButtonDown("Fire1"))
        {
            shoot = true;
            InvokeRepeating("shooot", 0.125f, 0.25f);
        }
        if(Input.GetButtonUp("Fire1"))
        {
            shoot = false;
            CancelInvoke("shooot");
        }
    }

 
    // jump code again but have link to controller2D script
    private void FixedUpdate()
    {
        controller2D.Move(move*Time.fixedDeltaTime, false, jump);
        jump = false;
        anim.SetBool("IsShooting", shoot);
        
        
    }

    void shooot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
