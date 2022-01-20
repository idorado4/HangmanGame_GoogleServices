using System.Collections.Generic;

public interface ILocalRankingService
{
    List<RankingData> GetLocalRanking();
    void UpdateLocalRanking(List<RankingData> rankingData);
}