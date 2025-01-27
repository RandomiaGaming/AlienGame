using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float bounce;
    public bool bouncer;
    private Vector2 velocity;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.one * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
            
            RaycastTest(new Vector2(0, 0.4f));
            RaycastTest(new Vector2(0, -0.4f));
            RaycastTest(new Vector2(0.4f, 0));
            RaycastTest(new Vector2(-0.4f, 0));

        if (bouncer)
        {
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = velocity;
        }
    }
    void RaycastTest(Vector2 direction)
    {

        RaycastHit2D output = Physics2D.Linecast(transform.position, (Vector2)transform.position + direction);
        if (output)
        {
            if(output.collider.gameObject.tag == "Player")
            {
                output.collider.gameObject.GetComponent<PlayerController>().dead = true;
            }
            if (direction.x != 0)
            {
                velocity = new Vector2(Mathf.Sign(direction.x * -1) * speed, velocity.y);
            }
            if (direction.y != 0)
            {
                if (bouncer && Mathf.Sign(direction.y) == -1)
                {
                    rb.velocity = new Vector2(rb.velocity.x, bounce);
                }
                velocity = new Vector2(velocity.x, Mathf.Sign(direction.y * -1) * speed);
            }
        }
    }
}
