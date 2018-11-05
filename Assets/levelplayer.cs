using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class levelplayer : MonoBehaviour {
    private Animator an;
    public Leveldot currentlevel;
    public Vector3 dotoffset;
    public Tilemap tilemap;
    public Tile[] paths;
    public Tile[] dots;
    public Color unlocked;
    public Color locked;
	// Use this for initialization
	void Start () {
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                Move(new Vector2(Input.GetAxisRaw("Horizontal"), 0));
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                Move(new Vector2(0, Input.GetAxisRaw("Vertical")));
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            currentlevel.Enter();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            currentlevel.SetCanEnter(true);
        }
        transform.position = currentlevel.transform.position + dotoffset;
        if (!an.GetCurrentAnimatorStateInfo(0).IsName("running"))
        {
            an.Play("running");
        }
	}
    public void Move(Vector2 direction)
    {
        Vector3 pos = transform.position;
        while(true)
        {
            
            pos = (Vector2)pos + direction;
            Tile returnedtile = (Tile)tilemap.GetTile(tilemap.WorldToCell(pos));
            
            bool isroad = false;
            bool isdot = false;
            foreach (Tile current in paths)
            {
                if (returnedtile == current)
                {
                    isroad = true;
                }
            }

            if (!isroad)
            {
                foreach (Tile current in dots)
                {
                    if (returnedtile == current)
                    {
                        isdot = true;
                    }
                }

                if (isdot)
                {
                    foreach(GameObject go in GameObject.FindGameObjectsWithTag("leveldot"))
                    {
                        
                        if(tilemap.WorldToCell(go.transform.position) == tilemap.WorldToCell(pos))
                        {
                            currentlevel = go.GetComponent<Leveldot>();
                        }
                    }
                }
                return;
            }
            
        }
    }
}
