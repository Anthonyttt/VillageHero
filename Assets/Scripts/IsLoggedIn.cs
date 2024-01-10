using System.Collections;
using System.Collections.Generic;
using PlayFab;
using UnityEngine;

public class IsLoggedIn : MonoBehaviour
{
    public GameObject rankButton;
    void Start()
    {
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            rankButton.SetActive(true);
        }
    }
    
}
