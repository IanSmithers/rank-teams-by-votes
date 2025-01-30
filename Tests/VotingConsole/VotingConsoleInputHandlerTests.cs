using RankedVotingConsoleApp.VotingConsole;

namespace Tests.VotingConsole;

[TestFixture]
public class VotingConsoleInputHandlerTests
{
    private StringWriter _writer;
    private readonly string _invalidInputResponseMessage = $"Invalid input detected, please enter your votes in the format of: [\"ABC\",\"DEF\"]{Environment.NewLine}";
    
    [SetUp]
    public void Setup()
    {
        _writer = new StringWriter();
        Console.SetOut(_writer);
    }
    
    [TearDown]
    public void TearDown()
    {
        _writer.Dispose();
    }
    
    [TestCase("FOOBAR")]
    public void CorrectlyHandlesInvalidInput(string input)
    {
        var output = VotingConsoleInputHandler.Handle(input);
        
        Assert.Multiple(() =>
        {
            Assert.That(output, Is.Empty);
            Assert.That(_writer.ToString(), Is.EqualTo(_invalidInputResponseMessage));
        });
    }
    
    [TestCase(null)]
    public void CorrectlyHandlesNullInput(string? input)
    {
        var output = VotingConsoleInputHandler.Handle(input);

        Assert.That(output, Is.Empty);
    }
    
    [TestCase("")]
    public void CorrectlyHandlesEmptyInput(string input)
    {
        var output = VotingConsoleInputHandler.Handle(input);

        Assert.That(output, Is.Empty);
    }
    
    [TestCase("[\"WXYZ\", \"XYWZ\"]")]
    public void CorrectlyHandlesValidInput(string input)
    {
        var output = VotingConsoleInputHandler.Handle(input);

        Assert.That(output, Is.EqualTo("XWYZ"));
    }
}
