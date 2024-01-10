using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using UnityEngine;

public class TableInteface : MonoBehaviour
{
    public GameObject rankInteface;
    public GameObject loginInteface;
    private PlayerfabManager playerfabManager = new PlayerfabManager();

    

    public void OpenLogin()
    {
        loginInteface.SetActive(true);
    }

    public void OpenRank()
    {
        playerfabManager.GetLeaderboard();
        rankInteface.SetActive(true);
    }

    public void CloseLogin()
    {
        loginInteface.SetActive(false);
    }

    public void CloseRank()
    {
        rankInteface.SetActive(false);
    }
}
