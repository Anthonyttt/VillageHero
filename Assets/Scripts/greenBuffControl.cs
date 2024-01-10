using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenBuffControl : MonoBehaviour
{
    private string[] buffTag = new string[2] { "移动速度", "血量" };
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
            if (buffTag[n] == "移动速度")
            {
                other.GetComponent<PlayerControl>().player.moveSpeed += value[m];
            }
            else
            {
                other.GetComponent<PlayerControl>().player.healthy += value[m];
            }
            Destroy(gameObject);
        }
        
    }
}
