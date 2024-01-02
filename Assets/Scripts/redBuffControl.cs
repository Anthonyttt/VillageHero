using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBuffControl : MonoBehaviour
{
    private int[] value = new int[10] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3 };
    private int n;
    void Start()
    {
        n = Random.Range(0, 10);
        transform.Find("info").GetComponent<TextMesh>().text = "杀戮光环速度 +"+ value[n] as string;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            other.GetComponent<PlayerControl>().rotationSpeed += value[n];
            Destroy(gameObject);
        }
        
    }
}
