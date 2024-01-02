using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class blueBuffControl : MonoBehaviour
{
    private string[] buffTag = new string[2] { "箭矢速度", "射击频率" };
    private int[] value = new int[10] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3 };
    private int n, m;
    
    void Start()
    {
        n = Random.Range(0, 2);
        m = Random.Range(0, 10);
        transform.Find("info").GetComponent<TextMesh>().text = buffTag[n] +" +"+ value[m] as string;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (buffTag[n] == "箭矢速度")
            {
                other.GetComponent<PlayerControl>().arrowSpeed += value[m];
            }
            else
            {
                other.GetComponent<PlayerControl>().frequency += value[m];
            }
            Destroy(gameObject);
        }
        
    }
}
