using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour {
    public Transform point1;
    public Transform point2;
    public float speed;
    public bool ForwardRaycast;
    private int direction = -1;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        RaycastHit2D output = Physics2D.Linecast(point1.position, point2.position);
        if (output)
        {
            if(output.collider.gameObject.tag == "Player")
            {
                GetComponent<Enemy>().DamagePlayer();
            }
            direction *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }
	}
}
