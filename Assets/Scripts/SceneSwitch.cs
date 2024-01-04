using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public GameObject stopIntface;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            StopGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        //在打包出来的环境下
        Application.Quit();
    }

    public void BackToTitle()
    {
        
        SceneManager.LoadScene("TitleScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("scene").GetComponent<SceneMove>().moveSpeed = 0;
        Instantiate(stopIntface);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("scene").GetComponent<SceneMove>().moveSpeed = 50f;
        Destroy(transform.root.gameObject);
    }
}
