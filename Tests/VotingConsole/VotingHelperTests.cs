using RankedVotingConsoleApp.VotingConsole;

namespace Tests.VotingConsole;

[TestFixture]
public class VotingHelperTests
{
    [TestCase("WXYZ", "WAXY")]
    public void ExpectedLengthIsFour(params string[] input)
    {
        Assert.That(() => VotingHelpers.GetExpectedLengthOfAllVotes(input), Is.EqualTo(4));
    }

    [TestCase("")]
    public void ExpectedLengthIsZero(params string[] input)
    {
        Assert.That(() => VotingHelpers.GetExpectedLengthOfAllVotes(input), Is.EqualTo(0));
    }
}
