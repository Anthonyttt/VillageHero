using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 血量
    public float healthy = 20.0f;
    // 移动速度
    public float moveSpeed = 50.0f;
    // 箭矢射击频率
    public float frequency = 10.0f;
    // 箭矢飞行速度
    public float arrowSpeed = 30.0f;
    //箭矢数量
    public int arrowCount = 1;
    // 杀戮光环旋转速度
    public float rotationSpeed = 10.0f;
    // 是否有杀戮光环
    public bool killingHalo = false;
    // 是否有火矢buff
    public bool fire = false;
    public GameObject sword;
    public GameObject arrow;
    public GameObject fireArrow;
    public Transform shotPoint;
    public int equipLevel=0;
    public GameObject gameOverIntface;
    private GameObject healthyInfo;
    private GameObject[] swordPoint;
    private int swordCount = 0;
    private Animator anim;
    private bool gameOver = false;

    private void Start()
    {
        Time.timeScale = 1;
        //发射箭矢
        StartCoroutine(shotArrow());
        transform.Find("healthy").GetComponent<TextMesh>().text = ((int)Math.Floor(healthy)).ToString();
        swordPoint = GameObject.FindGameObjectsWithTag("swordpoint");
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        // 左右移动
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.z > 1.0)
            {
                transform.Translate(Vector3.left* (moveSpeed/5f)*Time.deltaTime);

            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey((KeyCode.RightArrow)))
        {
            if (transform.position.z < 5.3)
            {
                transform.Translate(Vector3.right* (moveSpeed/5f)*Time.deltaTime);
            }
        }
        // 显示血量
        transform.Find("healthy").GetComponent<TextMesh>().text = ((int)Math.Floor(healthy)).ToString();
        // anim.SetFloat("shotSpeed",7f*frequency);
        if (healthy <= 0)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("scene").GetComponent<SceneMove>().moveSpeed = 0;
            if (!gameOver)
            {
                Instantiate(gameOverIntface);
                gameOver = true;
            }
        }

    }
    //利用协程，定时发射箭矢
    private IEnumerator shotArrow()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f / frequency);
            createArrow();
        }
        
    }
    private void createArrow()
    {
        GameObject t = arrow;
        if (fire)
        {
            t = fireArrow;
        }
        //0.26
        Vector3 defaultPositon = new Vector3(shotPoint.position.x, shotPoint.position.y, shotPoint.position.z - 0.13f);
        if (arrowCount == 1)
        {
            Instantiate(t, shotPoint.position,shotPoint.rotation);
        }
        else
        {
            float n = 0.26f / (arrowCount - 1);
            for (int i = 0; i < arrowCount; i++)
            {
                Instantiate(t, defaultPositon,shotPoint.rotation);
                defaultPositon.z += n;
            }
        }
        
        
    }

    public void createSword()
    {
        Instantiate(sword, swordPoint[swordCount].transform.position, swordPoint[swordCount].transform.rotation, swordPoint[swordCount].transform);
    }
}
