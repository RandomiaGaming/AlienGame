using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public int damage;
    public float timebtwshots;
    private float current;
    public GameObject particals;
    public GameObject flash;
    public Transform flashpos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("shoot"))
        {
            current += Time.deltaTime;
            if (current >= timebtwshots)
            {
                current = 0;
                RaycastHit2D output = Physics2D.Raycast(transform.position, new Vector2(transform.parent.localScale.x, 0));
                if (output)
                {
                    Instantiate(particals, output.point, Quaternion.identity);
                   // Instantiate(flash, flashpos.position, Quaternion.identity);

                    if (output.collider.gameObject.GetComponent<Health>() != null)
                    {
                        
                        output.collider.gameObject.GetComponent<Health>().Damage(damage);
                    }
                }


            }
        }
        else
        {
            current = timebtwshots;
        }

    }
}
