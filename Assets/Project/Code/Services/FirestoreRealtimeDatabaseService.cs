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

                    foreach (var player in orderedRanking.Children)
                    {
                        IDictionary dictionary = (IDictionary) player.Value;

                        var newRankingData = new RankingData()
                        {
                            Position = 0,
                            Username = player.Key,
                            Score = Int32.Parse(dictionary["SCORE"].ToString()),
                            Time = dictionary["TIME"].ToString()
                        };

                        ranking.Add(newRankingData);
                    }

                    int maxPlayers = 10;
                    int position = 1;
                    List<RankingData> rankingFlip = new List<RankingData>();
                    for (int i = ranking.Count - 1; maxPlayers > 0; i--, maxPlayers--, position++)
                    {
                        ranking[i].Position = position;
                        rankingFlip.Add(ranking[i]);
                    }

                    ServiceLocator.Instance.GetService<ILocalRankingService>().UpdateLocalRanking(rankingFlip);
                }
            });
    }

    public async void UpdateRankingData(int score, string time)
    {
        var db = FirebaseDatabase.DefaultInstance;

        var username = ServiceLocator.Instance.GetService<IUserDataAccessService>().GetLocalUser().Username;
        Debug.Log(username);

        string currentPoints = "";

        await db
            .GetReference($"ranking")
            .Child($"{username}")
            .Child("SCORE")
            .GetValueAsync()
            .ContinueWithOnMainThread(task => { currentPoints = task.Result.Value.ToString(); });

        if (Int32.Parse(currentPoints) >= score) return;
        
        Debug.Log("el score es superior, actualizo ranking");
        
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