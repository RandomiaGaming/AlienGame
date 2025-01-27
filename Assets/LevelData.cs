using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Data
{
    public string levelname;
    public bool unlocked;
}
public class LevelData : MonoBehaviour {
    public Data[] data;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < GameObject.FindGameObjectWithTag("levels").transform.GetChild(0).childCount; i++)
        {

            GameObject.FindGameObjectWithTag("levels").transform.GetChild(0).GetChild(i).GetComponent<Leveldot>().SetCanEnter(data[i].unlocked);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
