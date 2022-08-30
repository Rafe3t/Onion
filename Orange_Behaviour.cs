using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Orange_Behaviour : MonoBehaviour
{
    public GameObject detector;
    public bool Isfound = false;
    public Rigidbody2D rb;
    public float Orange_Speed;
    public Animator anim;
    public Transform player;
    public bool blowing = false;
    bool isactivated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("reverse", 0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetFloat("Speed", math.abs(rb.velocity.x));
        GameObject playerobj = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player = playerobj.transform;
            player = playerobj.transform;

            if (Isfound == false)
            {
                moove();
            }
            

            if (Isfound == true & blowing == false)
            {
                transform.right = new Vector2(player.position.x - transform.position.x, 0f);

                if (player.transform.position.x - transform.position.x >= 2 | player.transform.position.x - transform.position.x <= -2)
                {
                    rb.velocity = (new Vector2(player.position.x - transform.position.x, 0).normalized * Orange_Speed) + new Vector2(0f, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                    blowing = true;
                }
            }
            if (blowing == true & isactivated == false)
            {
                Orange_Health orange_Health = GetComponent<Orange_Health>();
                orange_Health.OrangeDamage(200);
                rb.velocity = new Vector2(0f, rb.velocity.y);
                isactivated = true;

            }
        }
        else
        {
            CancelInvoke("reverse");
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
    void moove()
    {
        rb.velocity = new Vector2(transform.right.x, 0) * Orange_Speed + new Vector2(0, rb.velocity.y);
    }
    void reverse()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
