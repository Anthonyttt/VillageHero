using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossArrowControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float harm = 3.0f;
    private float startX;
    void Start()
    {
        transform.GetComponent<Rigidbody>().velocity=Vector3.right*6f;
        startX = transform.position.x;
    }

    private void Update()
    {
        //箭矢超出飞行距离就会消失
        if (transform.position.x - startX > 40.0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            other.transform.GetComponent<PlayerControl>().player.healthy -= harm*((float)Math.Pow(0.9f,other.transform.GetComponent<PlayerControl>().equipLevel));
        }
    }

    
}
