using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;


public class PlayerfabManager : MonoBehaviour
{
    [Header("Leaderboard")]
    public GameObject listItem;
    public Transform parent;


    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "scoreRank",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderBoardUpdate, OnError);
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "scoreRank",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request,onLeaderBoardGet,OnError);
    }

    void onLeaderBoardGet(GetLeaderboardResult result)
    {
        GameObject.Find("Content").GetComponent<RankManager>().ClearItem();
        foreach (var item in result.Leaderboard)
        {
            GameObject.Find("Content").GetComponent<RankManager>().add(item);
        }
    }
    
    
    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent");
    }
    
    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
