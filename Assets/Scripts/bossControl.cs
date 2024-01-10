using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossControl : MonoBehaviour
{
    public Transform shotPoint;

    public GameObject arrow;
    public GameObject bigChest;
    public float healthy ;

    private GameObject father;

    private bool isBurn=false;

    private CatchLua catchLua=new CatchLua();
    // Start is called before the first frame update
    private void Start()
    {
        healthy = catchLua.ToHealthy("boss");
        StartCoroutine(shotArrow());
        father = GameObject.FindGameObjectWithTag("scene");
        
    }

    private void Update()
    {
        if (healthy <= 0)
        {
            Instantiate(bigChest,gameObject.transform.position, new Quaternion(0.0f,180.0f,0.0f,0.0f),father.transform);
            Destroy(gameObject);
        }

        transform.Find("healthy").GetComponent<TextMesh>().text = ((int)Math.Floor(healthy)).ToString();
    }


    private IEnumerator shotArrow()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            Instantiate(arrow, shotPoint.position, shotPoint.rotation, father.transform);
        }
    }
    private IEnumerator burn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            healthy -= 0.2f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.GetComponent<PlayerControl>().player.healthy -= healthy*((float)Math.Pow(0.9f,other.transform.GetComponent<PlayerControl>().equipLevel));
            healthy -= other.transform.GetComponent<PlayerControl>().player.healthy;
        }
        else if (other.tag == "arrow")
        {
            healthy -= other.gameObject.GetComponent<arrowControl>().harm;
        }
        else if (other.tag == "fireArrow")
        {
            healthy -= other.gameObject.GetComponent<arrowControl>().harm;
            if (!isBurn)
            {
                StartCoroutine(burn());
            }
        }
    }
}
