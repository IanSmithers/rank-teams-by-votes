using RankedVotingConsoleApp.VotingConsole;

namespace Tests.VotingConsole;

[TestFixture]
public class VotingInputValidatorTests
{
    [TestCase("WXYZ", "WAXY", "ZWXY")]
    public void MeetsAllValidationConditions(params string[] input)
    {
        Assert.That(() => VotingInputValidator.Validate(input), Is.EqualTo(true));
    }
    
    [TestCase("WXYZ", "WZXY", "ZWXYA")]
    public void FailsAllEqualLengthValidation(params string[] input)
    {
        Assert.That(() => VotingInputValidator.Validate(input), Is.EqualTo(false));
    }
    
    [TestCase("wXYZ", "WZXY", "ZWXY")]
    public void FailsAllUppercaseValidation(params string[] input)
    {
        Assert.That(() => VotingInputValidator.Validate(input), Is.EqualTo(false));
    }
    
    [TestCase("WXYZ", "W1XY", "ZWXY")]
    public void FailsAllAlphaOnlyValidation(params string[] input)
    {
        Assert.That(() => VotingInputValidator.Validate(input), Is.EqualTo(false));
    }
    
    [TestCase("WAXY", "WZXY", "WXYZ")]
    public void FailsAllUniqueValidation(params string[] input)
    {
        Assert.That(() => VotingInputValidator.Validate(input), Is.EqualTo(false));
    }
    
    [TestCase("", "", "")]
    public void FailsNotEmptyValidation(params string[] input)
    {
        Assert.That(() => VotingInputValidator.Validate(input), Is.EqualTo(false));
    }
}
