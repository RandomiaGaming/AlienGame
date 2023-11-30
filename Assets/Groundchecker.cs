using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Groundchecker : MonoBehaviour {
    public Transform[] points;
    public RuleTile ground;
    public Tilemap tilemap;
    public bool grounded;
	
	void Update () {
        grounded = false;
        
        foreach(Transform point in points)
        {
            
                if (tilemap.GetTile(tilemap.WorldToCell(point.position)) == ground)
                {
                    grounded = true;
                }
            
        }
        
    }
}
