using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneCreate : MonoBehaviour
{
    
    public GameObject scene;
    public Vector3 defaultPosition=new Vector3(-101,0,0);
    private Quaternion defaultQuaternion = new Quaternion(0, 0, 0,0);
    private GameObject father;

    private void Start()
    {
        father = GameObject.FindGameObjectWithTag("scene");
    }

    // 创建场景
    private void createScene()
    {
        Instantiate(scene,defaultPosition,defaultQuaternion,father.transform);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            createScene();
            GameObject.FindGameObjectWithTag("bosspoint").GetComponent<bossCreate>().sceneCount++;
        }
        
    }
}
