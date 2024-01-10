using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using UnityEngine;
using UnityEngine.UI;


public class Player
{
    public float healthy;
    public float moveSpeed;
    public float frequency;
    public float arrowSpeed;
    public int arrowCount;
    public float rotationSpeed;
}
public class PlayerControl : MonoBehaviour
{
    public Player player;
    
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
    private int score = 0;
    private Text scoreText;
    private PlayerfabManager playerfabManager=new PlayerfabManager();

    private CatchLua catchLua=new CatchLua();
    

    private void Start()
    {
        player=catchLua.MapToPlayer();
        Time.timeScale = 1;
        //发射箭矢
        StartCoroutine(shotArrow());
        transform.Find("healthy").GetComponent<TextMesh>().text = ((int)Math.Floor(player.healthy)).ToString();
        scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        StartCoroutine(scoreAdd());
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
                transform.Translate(Vector3.left* (player.moveSpeed/5f)*Time.deltaTime);

            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey((KeyCode.RightArrow)))
        {
            if (transform.position.z < 5.3)
            {
                transform.Translate(Vector3.right* (player.moveSpeed/5f)*Time.deltaTime);
            }
        }
        // 显示血量
        transform.Find("healthy").GetComponent<TextMesh>().text = ((int)Math.Floor(player.healthy)).ToString();
        // anim.SetFloat("shotSpeed",7f*frequency);
        if (player.healthy <= 0)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("scene").GetComponent<SceneMove>().moveSpeed = 0;
            if (!gameOver)
            {
                Instantiate(gameOverIntface);
                if (PlayFabClientAPI.IsClientLoggedIn())
                {
                    playerfabManager.SendLeaderBoard(score);

                }
                gameOver = true;
            }
        }

    }
    //利用协程，定时发射箭矢
    private IEnumerator shotArrow()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f / player.frequency);
            createArrow();
        }
        
    }
    
    // 计分
    private IEnumerator scoreAdd()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            score += 1; 
            scoreText.text = score.ToString();
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
        if (player.arrowCount == 1)
        {
            Instantiate(t, shotPoint.position,shotPoint.rotation);
        }
        else
        {
            float n = 0.26f / (player.arrowCount - 1);
            for (int i = 0; i < player.arrowCount; i++)
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
