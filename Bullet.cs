using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float BulletSpeed;
    public int Damager;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * BulletSpeed;
        Invoke("dest", 0.8f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "detectors" & collision.tag != "Bullets")
        {
            Banana_Health banana_health = collision.GetComponent<Banana_Health>();
            if(banana_health != null)
            {
                banana_health.BananaDamage(Damager);
            }
            Orange_Health orange_Health = collision.GetComponent<Orange_Health>();
            if(orange_Health != null)
            {
                orange_Health.OrangeDamage(Damager);
            }
            Peach_Health peach_Health = collision.GetComponent<Peach_Health>();
            if (peach_Health != null)
            {
                peach_Health.PeachDamage(Damager);
            }
            dest();
        }
        
    }

    void dest()
    {
        Destroy(gameObject);
    }
}
