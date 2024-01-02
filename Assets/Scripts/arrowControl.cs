using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class arrowControl : MonoBehaviour
{
    
    //箭矢伤害
    public float harm = 3.0f;
    // 箭矢飞行距离
    public float distance = 10.0f;
    //箭矢数量
    public int count = 1;
    //是否有穿透附魔
    public bool penetrate = false;

    private float startX;
    void Start()
    {
        float speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().arrowSpeed;
        GetComponent<Rigidbody>().velocity=Vector3.left*(speed/6f);
        startX = transform.position.x;
    }

    void Update()
    {
        if (startX - transform.position.x > distance)
        {
            Destroy(gameObject);
        }
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            if (penetrate==false)
            {
                Destroy(gameObject);
            }
        }
        
    }
    
}
