using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemy : MonoBehaviour {
    public bool leftright;
    private Vector2 startpos;
    private Rigidbody2D rb;
    public float speed = 2;
    private int direction = 1;
	// Use this for initialization
	void Start () {
        startpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (leftright)
        {
            rb.velocity = new Vector2(speed * direction, 0);
            if(transform.position.x >= startpos.x + 1.5f || transform.position.x <= startpos.x - 1.5f)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, startpos.x - 1.4f, startpos.x + 1.4f), Mathf.Clamp(transform.position.y, startpos.y - 1.4f, startpos.y + 1.4f), 0);
                direction *= -1;
            }
        }
        else
        {
            rb.velocity = new Vector2(0, speed * direction);
            if (transform.position.y >= startpos.y + 1.5f || transform.position.y <= startpos.y - 1.5f)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, startpos.x - 1.4f, startpos.x + 1.4f), Mathf.Clamp(transform.position.y, startpos.y - 1.4f, startpos.y + 1.4f), 0);
                direction *= -1;
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
    }
}
