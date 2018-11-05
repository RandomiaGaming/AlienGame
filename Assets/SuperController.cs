using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperController : MonoBehaviour {
    public int equipedsuper;

    private PlayerController player;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
    }
    void Update () {
        if (Input.GetButtonDown("usesuper") && player.dead == false)
        {
            switch (equipedsuper)
            {
                case 0:
                    break;
                case 1:
                    UseMiniDash();
                    break;
                
            }
        }
	}
    void UseMiniDash()
    {
        rb.velocity = new Vector2(player.moveforce * 2f * transform.localScale.x, rb.velocity.y);
    }
    
}
