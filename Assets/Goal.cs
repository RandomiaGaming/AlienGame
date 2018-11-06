using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Player");
            print(GameObject.FindGameObjectWithTag("LevelManager").name);
            print(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>());
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().Win();
        }
    }
}
