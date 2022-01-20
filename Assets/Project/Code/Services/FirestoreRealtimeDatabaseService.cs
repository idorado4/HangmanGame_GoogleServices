using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirestoreRealtimeDatabaseService : IRankingDataService
{
    public async Task GetRankingData()
    {
        var db = FirebaseDatabase.DefaultInstance;

        //PIDO A LA DATABASE QUE ME DEVUELVA TODOS LOS PLAYERS CON SUS PUNTUACIONES
        //ORDENADAS DE MENOR A MAYOR
        await db.GetReference("ranking")
            .OrderByChild("SCORE")
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("Imposible acceder al ranking");
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("ACCESO A RANKING");
                    //EN EL SNAPSHOT ESTÁ GUARDADO EL RANKING ORDENADO
                    var orderedRanking = task.Result;

                    List<RankingData> ranking = new List<RankingData>();
                    int maxPlayers = 10;

                    foreach (var player in orderedRanking.Children)
                    {
                        IDictionary dictionary = (IDictionary) player.Value;

                        var newRankingData = new RankingData()
                        {
                            Position = maxPlayers,
                            Username = player.Key,
                            Score = Int32.Parse(dictionary["SCORE"].ToString()),
                            Time = dictionary["TIME"].ToString()
                        };

                        ranking.Add(newRankingData);

                        maxPlayers--;
                        if (maxPlayers == 0) break;
                    }

                    List<RankingData> rankingFlip = new List<RankingData>();
                    for (int i = ranking.Count - 1; i >= 0; i--)
                    {
                        rankingFlip.Add(ranking[i]);
                    }

                    ServiceLocator.Instance.GetService<ILocalRankingService>().UpdateLocalRanking(rankingFlip);
                }
            });
    }

    public async void UpdateRankingData(int score, string time)
    {
        var db = FirebaseDatabase.DefaultInstance;
        Debug.Log(ServiceLocator.Instance.GetService<IUserDataAccessService>().GetLocalUser());
        IDictionary<string, object> update = new Dictionary<string, object>()
        {
            {$"{ServiceLocator.Instance.GetService<IUserDataAccessService>().GetLocalUser().Username}/SCORE", score},
            {$"{ServiceLocator.Instance.GetService<IUserDataAccessService>().GetLocalUser().Username}/TIME", time}
        };
        await db
            .GetReference("ranking")
            .UpdateChildrenAsync(update)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Ranking Actualizado");
                } 
            });
        await GetRankingData();
    }
}