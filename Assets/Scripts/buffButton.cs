using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class buffButton : MonoBehaviour
{
    
    private BuffType buffType;
    public Buff buff;

    private void Start()
    {
        Button button = transform.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void setIcon(Sprite icon)
    {
        transform.Find("Image").GetComponent<Image>().sprite = icon;
    }

    public void setName(string name)
    {
        transform.Find("Text").GetComponent<Text>().text = name;
    }

    public void setColor(Sprite color)
    {
        transform.GetComponent<Image>().sprite = color;
    }

    public void OnButtonClick()
    {
        buff.ApplyBuffToPlayer();
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("scene").GetComponent<SceneMove>().moveSpeed = 50f;
        Destroy(transform.root.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("bigchest"));
    }
    
    
}
