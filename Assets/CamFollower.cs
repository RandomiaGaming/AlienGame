using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour {
    private Vector3 offset;
    public Transform player;
    public bool islevelcam = false;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (islevelcam)
        {
            transform.position = player.position + offset;
        }
        else
        {
            if (player.GetComponent<PlayerController>().dead == false)
            {
                transform.position = player.position + offset;
            }
        }
	}
}
