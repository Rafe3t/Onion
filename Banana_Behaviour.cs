using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Banana_Behaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public GameObject detector;
    public bool Isfound = false;
    public bool IsActivated = false;
    public Rigidbody2D rb;
    public float Banana_Speed;
    public Animator anim;
    public Transform player;
    public Transform banana;


    private void Start()
    {
        InvokeRepeating("reverse", 0f, 1f);
    }


    // Update is called once per frame
    void Update()
    {
                anim.SetFloat("Movment", math.abs(rb.velocity.x));
                GameObject playerobj = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player = playerobj.transform;
                
                if (Isfound == false)
                {
                    moove();
                }
                if (Isfound == true & IsActivated == false)
                {
                    InvokeRepeating("shooot", 0.5f, 1f);
                    IsActivated = true;
                    anim.SetBool("IsShooting", true);
                    
                }

                if (Isfound == true)
                {
                    banana.transform.right = new Vector2(player.position.x - banana.position.x, 0f);

                    if (player.transform.position.x - banana.transform.position.x >= 6 | player.transform.position.x - banana.transform.position.x <= -6)
                    {
                    rb.velocity = (new Vector2(player.position.x - banana.position.x,0 ).normalized * Banana_Speed) + new Vector2(0f,rb.velocity.y);
                    }
                    else
                    {
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                    }
                }
            }
            else
        {
            CancelInvoke("shooot");
            CancelInvoke("reverse");
            anim.SetBool("IsShooting", false);
            rb.velocity = new Vector2(0f, 0f);
        }
        

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.tag == ("Player") | collision.tag == ("Perfect Bullet"))
           {
                Isfound = true;
                CancelInvoke("reverse");
           }
    }

    void shooot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
    void moove()
    {
        rb.velocity = new Vector2(transform.right.x,0)*Banana_Speed + new Vector2(0,rb.velocity.y);
    }
    
    void reverse()
    {
        
        transform.Rotate(0f, 180f, 0f);
    }



}
