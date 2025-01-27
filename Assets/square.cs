using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour {
    public float wait = 10;
    private float current;
    public Vector2 jump;
    public Transform player;
	// Use this for initialization
	void Start () {
        current = wait;
    }
	
	// Update is called once per frame
	void Update () {
        if(Mathf.Sign(jump.x) != Mathf.Sign(transform.position.x - player.position.x))
        {
            jump.x *= -1;
        }
        current -= Time.deltaTime;
        if(wait <= 0)
        {
            Jump();
            current = wait;
        }
	}
    public void Jump()
    {
       
        GetComponent<Rigidbody2D>().velocity = jump;
    }
}
