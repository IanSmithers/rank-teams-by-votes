namespace RankedVotingConsoleApp.VotingConsole;

public static class VotingWeights
{
    public static Dictionary<string, int> RankVotes(string[] incomingVotes)
    {
        var weightedDictionary = new Dictionary<string, int>();

        var voteLength = VotingHelpers.GetExpectedLengthOfAllVotes(incomingVotes);
            
        foreach (var vote in incomingVotes)
        {
            for(var i = 0; i < voteLength; i++)
            {
                var weight = voteLength - i;
                IncreaseOrAdd(weightedDictionary, vote[i].ToString(), weight);
            }
        }

        return weightedDictionary;
    }

    private static void IncreaseOrAdd(Dictionary<string, int> weightedDictionary, string key, int weight)
    {
        if (weightedDictionary.TryGetValue(key, out var value))
        {
            value += weight;
            weightedDictionary[key] = value;
        }
        else
        {
            weightedDictionary.Add(key, weight);
        }
    }
}
