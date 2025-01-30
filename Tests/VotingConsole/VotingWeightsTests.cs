using NuGet.Frameworks;
using NUnit.Framework.Constraints;
using RankedVotingConsoleApp.VotingConsole;

namespace Tests.VotingConsole;


[TestFixture]
public class VotingWeightsTests
{
    [TestCase("WXYZ", "WZXY", "ZWXY")]
    public void CorrectlyRanksValidVotes(params string[] input)
    {
        var expectedWeights = new Dictionary<string, int>()
        {
            { "W", 11 },
            { "X", 7 },
            { "Y", 4 },
            { "Z", 8 },
        };
        
        var actualWeights = VotingWeights.RankVotes(input);

        Assert.Multiple(() =>
        {
            Assert.That(expectedWeights["W"], Is.EqualTo(actualWeights["W"]));
            Assert.That(expectedWeights["X"], Is.EqualTo(actualWeights["X"]));
            Assert.That(expectedWeights["Y"], Is.EqualTo(actualWeights["Y"]));
            Assert.That(expectedWeights["Z"], Is.EqualTo(actualWeights["Z"]));
        });
    }
}
