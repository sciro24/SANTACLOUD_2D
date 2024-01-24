using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Public;
using PlayFab.SharedModels;



public class Play_Leaderboard : MonoBehaviour
{

    [Header("Leaderboard")]
    public GameObject rowPrefab;
    public Transform rowsParent;

    private static void OnError(PlayFabError Error) {
      
        Debug.Log(Error.GenerateErrorReport()); 
    }


    public static void SendLeaderboard(string WorldType, int score){
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = WorldType,
                    Value =  score
                }
            }
        };
          PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

 public static void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
    Debug.Log("Successful leaderboard sent");
}

public void GetLeaderboardVertical(){
    var request = new GetLeaderboardRequest {
        StatisticName = "TimeScoreVertical",
        StartPosition = 0,
        MaxResultsCount = 10
    };
    PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
}

public void GetLeaderboardHorizontal(){
    var request = new GetLeaderboardRequest {
        StatisticName = "TimeScoreHorizontal",
        StartPosition = 0,
        MaxResultsCount = 10
    };
    PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
}

public void OnLeaderboardGet(GetLeaderboardResult result){

    foreach (Transform  item in  rowsParent){
        Destroy(item.gameObject);
    }


    List<PlayerLeaderboardEntry> players = result.Leaderboard;
    players.Reverse();

     foreach (var item in players){
        
        GameObject newGo = Instantiate(rowPrefab, rowsParent);
        TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = (players.Count - item.Position).ToString();
        texts[1].text = item.DisplayName;
        texts[2].text = item.StatValue.ToString();


        Debug.Log(string.Format("PLACE: {0} | ID: {1} | VALUE: {2}", 
        item.Position, item.PlayFabId, item.StatValue));
    }
    
    
}

}


