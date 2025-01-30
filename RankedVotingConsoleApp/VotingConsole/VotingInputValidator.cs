namespace RankedVotingConsoleApp.VotingConsole;

public static class VotingInputValidator
{
    public static bool Validate(string[] votingInput)
    {
        return
            VotesNotEmpty(votingInput) &&
            VotesAllEqualLength(votingInput) &&
            VotesAllUpperCaseAlphaOnly(votingInput) &&
            VotesAreAllUnique(votingInput);
    }

    private static bool VotesNotEmpty(string[] votingInput)
    {
        return votingInput.All(a => a.Length > 0);
    }

    private static bool VotesAllEqualLength(string[] votingInput)
    {
        var requiredLength = votingInput[0].Length;

        return votingInput.All(a => requiredLength == a.Length);
    }

    private static bool VotesAllUpperCaseAlphaOnly(string[] votingInput)
    {
        return votingInput.All(a => a.All(char.IsUpper) && a.All(char.IsLetter));
    }

    private static bool VotesAreAllUnique(string[] votingInput)
    {
        return votingInput.All(votes =>
        {
            return votes
                .GroupBy(g => g)
                .All(a => a.Count() == 1);
        });
    }
}
