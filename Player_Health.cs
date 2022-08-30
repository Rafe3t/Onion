using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public Movment player_movment;
    public int health = 100;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject Player_Death;
    bool IsDead = false;
    public float knockback_dist;
    public CharacterController2D Controller2D;


    // damage is the ammount of damage you take , modified by this function in the damage object's code
    public void TakeDamage(int damage)
    {
        
        health -= damage;
        
        if (health <= 0)
        {
            if (IsDead == false)
            {
                die();
                IsDead = true;
            }
        }

    }
    public void die()
    {
        Destroy(gameObject);

        Instantiate(Player_Death, transform.position, transform.rotation);
    }

    //Knockback , the damgge is the object that damages you
    public void Knockback(Transform damgge)
    {
        
        Vector2 dircs = new Vector2(damgge.right.x*2,1f).normalized;
        anim.SetBool("IsDamaged", true);
        player_movment.enabled = false;
        transform.right = -damgge.right;
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(dircs * knockback_dist,ForceMode2D.Impulse);
        Invoke("ifgrounded", 0.2f);
        
        
    }
    //after being damaged by 0.2 seconds , (ifgrounded) will activate and everything will become normal again
    
    void ifgrounded()
    {
        player_movment.enabled = true;
        anim.SetBool("IsDamaged", false);
        
    }

    // when you touch something (death) is an object that kills you once you touch it and (enemy) damage you 30 when you touch it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Death")
        {
            die();
        }
        if(collision.collider.tag == "Enemy")
        {
            TakeDamage(30);
            Knockback(collision.transform);
        }
        
    }
    
    

}
