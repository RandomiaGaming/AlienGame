using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Leveldot : MonoBehaviour
{
    [HideInInspector]
    public Transform dot;
    public bool canenter;
    public string levelname;
    public Leveldot[] nextlevels;
    // Use this for initialization
    void Start()
    {
        dot = transform;
        if (canenter)
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().unlocked;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().locked;
        }

    }
   public void SetCanEnter(bool value)
    {
        canenter = value;
        if (canenter)
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().unlocked;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().locked;
        }
    }
    public void Enter()
    {
        if (canenter)
        {
            SceneManager.LoadSceneAsync(levelname);
        }
    }
    public void Complete()
    {
        foreach(Leveldot ld in nextlevels)
        {
            ld.SetCanEnter(true);
        }
    }
}
