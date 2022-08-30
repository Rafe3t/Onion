using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Orange_Health : MonoBehaviour
{
    public int health;
    public GameObject OrangeDeath;
    public Animator anim;
    public Transform player;
    bool IsDead = false;
    public SpriteRenderer dmgcolor;


    public void OrangeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Orange_Behaviour orange_Behaviour = gameObject.GetComponent<Orange_Behaviour>();
            orange_Behaviour.blowing = true;
            anim.SetBool("IsBlowing", true);
            if (IsDead == false)
            {
                Invoke("die", 0.8f);
                IsDead = true;
            }
        }
        else 
        {
            dmgcolor.color = new Color(1f, 0.7688679f, 0.7688679f);
            Invoke("nodmg", 0.1f);
        }
    }
    
   
    public void die()
    {
        
        Instantiate(OrangeDeath, transform.position - new Vector3(-0.08f,-0.569f), transform.rotation);
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        Invoke("ExplodeEffect", 0.3f);
        Invoke("dest", 0.4f);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Death")
        {
            die();
        }
    }
    void ExplodeEffect()
    {
        if (player != null)
        {
            
            player = GameObject.FindWithTag("Player").transform;
            Player_Health player_Health = player.gameObject.GetComponent<Player_Health>();
            float dist = math.sqrt(math.pow(transform.position.x - player.position.x, 2f) + math.pow(transform.position.y - player.position.y, 2f));
            Vector2 dircs = (player.position - transform.position);
            Rigidbody2D PlayerRB = player_Health.gameObject.GetComponent<Rigidbody2D>();
            
            
            if (dist <= 2f)
            {
                player_Health.TakeDamage(150);
                player_Health.Knockback(transform);
            }
            if (dist <= 4f & dist > 2f)
            {
                player_Health.TakeDamage(80);
                player_Health.Knockback(transform);
            }
            if (dist <= 4.5f & dist > 4f)
            {
                player_Health.TakeDamage(20);
                player_Health.Knockback(transform);
            }
        }
    }
    void dest()
    {
        Destroy(gameObject);
    }
    void nodmg()
    {
        dmgcolor.color = new Color(1, 1, 1);
    }
}
