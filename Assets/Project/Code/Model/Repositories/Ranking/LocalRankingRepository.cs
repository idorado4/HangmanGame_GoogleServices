
using System.Collections.Generic;

public class LocalRankingRepository : ILocalRankingService
{
    private List<RankingData> _ranking;
    
    public List<RankingData> GetLocalRanking()
    {
        return _ranking;
    }

    public void UpdateLocalRanking(List<RankingData> rankingData)
    {
        _ranking = rankingData;
    }
}
