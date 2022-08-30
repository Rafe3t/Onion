using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana_Health : MonoBehaviour
{
    public int health;
    public SpriteRenderer dmgcolor;
    public GameObject Banana_death;

    
    public void BananaDamage(int damage)
    {
        health -= damage;
        changecolor();
        Invoke("resetcolor", 0.1f);
        if (health <= 0)
        {
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
        Instantiate(Banana_death, transform.position, transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Death")
        {
            die();
        }
    }

    void changecolor()
    {
        dmgcolor.color = new Color(1f, 0.7688679f, 0.7688679f);
    }
    void resetcolor()
    {
        dmgcolor.color = new Color(1f, 1f, 1f);
    }
}
