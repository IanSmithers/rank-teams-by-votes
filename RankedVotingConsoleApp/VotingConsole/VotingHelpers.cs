namespace RankedVotingConsoleApp.VotingConsole;

public static class VotingHelpers
{
    public static int GetExpectedLengthOfAllVotes(string[] votes)
    {
        // The expectation is that all votes are of equal length as such any item's length in the collection indicates the vote length.
        return votes.First().Length;
    }
}
