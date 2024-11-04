using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {
    public Color unlocked;
    public Color locked;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("LevelManager").Length < 2)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
	}
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "levelselect")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
           transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public	void Win()
    {
        print("won");   
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if(transform.GetChild(0).GetChild(i).GetComponent<Leveldot>().levelname == SceneManager.GetActiveScene().name)
            {
                print("foundchild");
                transform.GetChild(0).GetChild(i).GetComponent<Leveldot>().Complete();
            }
        }
        print("loadingscene");
        SceneManager.LoadSceneAsync("levelselect");
    }
}
