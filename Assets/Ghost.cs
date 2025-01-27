using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    private Transform player;
    public float MaxDistanceDelta;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        MaxDistanceDelta *= 0.001f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(Mathf.Sign(player.position.x - transform.position.x), 1, 1);
        transform.position = Vector3.MoveTowards(transform.position, player.position, MaxDistanceDelta);
	}
}
