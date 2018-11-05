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

    // Use this for initialization
    void Start()
    {
        dot = transform;
        if (canenter)
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Player").GetComponent<levelplayer>().unlocked;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Player").GetComponent<levelplayer>().locked;
        }

    }
   public void SetCanEnter(bool value)
    {
        canenter = value;
        if (canenter)
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Player").GetComponent<levelplayer>().unlocked;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Player").GetComponent<levelplayer>().locked;
        }
    }
    public void Enter()
    {
        if (canenter)
        {
            SceneManager.LoadSceneAsync(levelname);
        }
    }

}
