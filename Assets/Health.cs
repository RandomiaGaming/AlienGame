using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
    public bool player;

    public string ouchanimation;
    
    public void Damage(int damage)
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(ouchanimation) && ouchanimation != "")
        {
            GetComponent<Animator>().Play(ouchanimation);
        }
        health -= damage;
        if(health <= 0)
        {
            if (player)
            {
                GetComponent<PlayerController>().dead = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
