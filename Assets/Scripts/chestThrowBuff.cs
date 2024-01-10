using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class chestThrowBuff : MonoBehaviour
{
    private string[] buffTag = new string[7] { "移动速度", "血量", "箭矢速度", "射击频率", "箭矢距离","箭矢距离","箭矢距离" };
    private int[] value = new int[10] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3 };
    private int n, m;
    void Start()
    {
        n = Random.Range(0, 7);
        m = Random.Range(0, 10);
        transform.Find("info").GetComponent<TextMesh>().text = buffTag[n] +" +"+ value[m] as string;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (buffTag[n] == "移动速度")
            {
                other.GetComponent<PlayerControl>().player.moveSpeed += value[m];
            }
            else if (buffTag[n] == "血量")
            {
                other.GetComponent<PlayerControl>().player.healthy += value[m];
            }
            else if (buffTag[n] == "箭矢速度")
            {
                other.GetComponent<PlayerControl>().player.arrowSpeed += value[m];
            }
            else if (buffTag[n] == "射击频率")
            {
                other.GetComponent<PlayerControl>().player.frequency += value[m];
            }
            else
            {
                GameObject.FindGameObjectWithTag("arrow").transform.GetComponent<arrowControl>().distance += value[m];
            }
            Destroy(gameObject);
            Debug.Log("箱子被捡了");
        }
    }
}
