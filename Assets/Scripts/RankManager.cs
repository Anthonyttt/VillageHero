using System.Collections;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    public GameObject listItem;
    public void add(PlayerLeaderboardEntry item)
    {
        GameObject newGo = Instantiate(listItem, transform);
        Text[] texts = newGo.GetComponentsInChildren<Text>();
        texts[0].text = (item.Position + 1).ToString();
        texts[1].text = item.DisplayName;
        texts[2].text = item.StatValue.ToString();
    }

    public void ClearItem()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
    }
}
