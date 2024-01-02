using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class buffCreate : MonoBehaviour
{
    public Transform[] point=new Transform[4];
    public GameObject blue;
    public GameObject green;
    public GameObject red;
    private GameObject father;
    private GameObject player;
    void Start()
    {
        father = GameObject.FindGameObjectWithTag("scene");
        player = GameObject.FindGameObjectWithTag("Player");
        createBuff();
    }

    private void createBuff()
    {
        int limit = 2;
        // if (player.transform.GetComponent<PlayerControl>().killingHalo)
        // {
        //     limit = 3;
        // }
        for (int i=0;i<4;i++)
        {
            int t = Random.Range(0, limit);
            if (t == 0)
            {
                Debug.Log("生成蓝色buff");
                Instantiate(blue, point[i].position, point[i].rotation,father.transform);
            }
            else if (t == 1)
            {
                Debug.Log("生成绿色buff");
                Instantiate(green, point[i].position, point[i].rotation,father.transform);
            }
            else
            {
                Debug.Log("生成红色buff");
                Instantiate(red, point[i].position, point[i].rotation,father.transform);
            }
        }
        
    }
}
