using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    public Vector3 startpos;
    public bool dead;
    public float moveforce;
    public float jumpforce;
    private Rigidbody2D rb;
    private float direction = 1;
    private Animator an;
    private bool exploding;
    public Groundchecker groundchecker;
    public Tile[] ouches;
    
    // Use this for initialization
    void Start()
    {
        startpos = transform.position;
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!dead)
        {
            if (Input.GetButtonDown("Jump") && groundchecker.grounded)
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }

            RefershAnimation();
            transform.localScale = new Vector3(direction, 1, 1);
            if (Input.GetAxisRaw("Horizontal") != 0)
            {

                direction = Input.GetAxisRaw("Horizontal");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                dead = true;
            }

            if (Input.GetAxisRaw("Horizontal") == 1 && rb.velocity.x < moveforce + 0.001f)
            {
                rb.velocity = new Vector2(moveforce * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            }
            else if (Input.GetAxisRaw("Horizontal") == -1 && rb.velocity.x > -moveforce - 0.001f)
            {
                rb.velocity = new Vector2(moveforce * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            }
            else if (Input.GetAxisRaw("Horizontal") == 0)
            {
                rb.velocity = new Vector2(moveforce * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            if (!an.GetCurrentAnimatorStateInfo(0).IsName("boom"))
            {
                an.Play("boom");
            }
            if (an.GetCurrentAnimatorStateInfo(0).IsName("boom"))
            {
                exploding = true;
            }
            if (!an.GetCurrentAnimatorStateInfo(0).IsName("boom") && exploding)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        if (collision.gameObject.GetComponent<Tilemap>() != null)
        {
            Tilemap collided = collision.gameObject.GetComponent<Tilemap>();
            foreach (ContactPoint2D hit in collision.contacts)
            {

                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;


            }
            TileBase hittile = null;

            hittile = collided.GetTile(collided.WorldToCell(hitPosition));

            foreach (Tile tile in ouches)
            {
                if (hittile == tile)
                {
                    dead = true;
                }
            }
        }

    }

void RefershAnimation()
{

    if (groundchecker.grounded && Input.GetAxisRaw("Horizontal") != 0)
    {
        if (!an.GetCurrentAnimatorStateInfo(0).IsName("running"))
        {
            an.Play("running");
        }
    }
    else if (!groundchecker.grounded && rb.velocity.y > 0)
    {
        an.Play("jumping");
    }
    else if (!groundchecker.grounded && rb.velocity.y < 0)
    {
        an.Play("falling");
    }
    else
    {
        if (!an.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            an.Play("idle");
        }
    }
}
}

