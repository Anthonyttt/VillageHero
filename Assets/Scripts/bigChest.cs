using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigChest : MonoBehaviour
{
    private GameObject Scene;

    public GameObject intface;
    // Start is called before the first frame update
    void Start()
    {
        Scene = GameObject.FindGameObjectWithTag("scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            Scene.transform.GetComponent<SceneMove>().moveSpeed = 0;
            Instantiate(intface);
        }
    }
}
