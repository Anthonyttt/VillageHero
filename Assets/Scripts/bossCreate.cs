using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCreate : MonoBehaviour
{
    public int sceneCount = 0;
    public GameObject boss;
    private GameObject father;
    void Start()
    {
        father = GameObject.FindGameObjectWithTag("scene");
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneCount > 0)
        {
            createBoss();
            sceneCount = 0;
        }
    }

    private void createBoss()
    {
        Instantiate(boss, transform.position, transform.rotation, father.transform);
    }
}
