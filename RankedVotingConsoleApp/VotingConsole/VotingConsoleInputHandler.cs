using System.Text;
using System.Text.Json;

namespace RankedVotingConsoleApp.VotingConsole;

public static class VotingConsoleInputHandler
{
    private const bool IsDebug = false;
    
    public static string Handle(string? inputString)
    {
        if(inputString == null) return string.Empty;

        try
        {
            var results = JsonSerializer.Deserialize<string[]>(inputString);
            if (results is { Length: > 0 } && VotingInputValidator.Validate(results))
            {
                var weights = VotingWeights.RankVotes(results);
                var orderedWeights = weights.OrderByDescending(o => o.Value);

                var sb = new StringBuilder();
                foreach (var pair in orderedWeights)
                {
                    if (IsDebug)
                    {
                        sb.AppendLine($"Team {pair.Key}: Points: {pair.Value}");
                    }
                    else
                    {
                        sb.Append(pair.Key);
                    }
                }

                return sb.ToString();
            }

            return string.Empty;
        }
        catch (JsonException)
        {
            Console.WriteLine("Invalid input detected, please enter your votes in the format of: [\"ABC\",\"DEF\"]");
            
            return string.Empty;
        }
    }
}
