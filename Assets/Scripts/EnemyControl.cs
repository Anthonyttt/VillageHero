using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyControl : MonoBehaviour
{
    public float BloodVolume;

    public GameObject chest;
    private GameObject father;
    private bool isBurn = false;

    private CatchLua catchLua=new CatchLua();
    void Start()
    {
        BloodVolume = catchLua.ToHealthy("enemy");
        father = GameObject.FindGameObjectWithTag("scene");
        transform.Find("healthy").GetComponent<TextMesh>().text = ((int)Math.Floor(BloodVolume)).ToString();
    }

    void Update()
    {
        if (BloodVolume <= 0)
        {
            Destroy(gameObject);
            Instantiate(chest, transform.position, Quaternion.Euler(0,180,0), father.transform);
        }
        transform.Find("healthy").GetComponent<TextMesh>().text = ((int)Math.Ceiling(BloodVolume)).ToString();
    }

    private IEnumerator burn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            BloodVolume -= 0.2f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "arrow")
        {
            BloodVolume-=other.GetComponent<arrowControl>().harm;
        }else if (other.tag == "sword")
        {
            BloodVolume -= other.GetComponent<KillauraControl>().harm;
        }else if (other.tag == "fireArrow")
        {
            BloodVolume -= other.GetComponent<arrowControl>().harm;
            if (!isBurn)
            {
                StartCoroutine(burn());
            }
        }
        else if (other.tag == "Player")
        {
            other.transform.GetComponent<PlayerControl>().player.healthy -= BloodVolume*((float)Math.Pow(0.9f,other.transform.GetComponent<PlayerControl>().equipLevel));
            BloodVolume -= other.GetComponent<PlayerControl>().player.healthy;
        }
        
    }
}
