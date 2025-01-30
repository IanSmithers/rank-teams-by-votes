namespace RankedVotingConsoleApp.VotingConsole;

public static class VotingTerminal
{
    public static void StartPrompt()
    {
        while (true)
        {
            Console.WriteLine("Please enter your votes: ");
            var inputString = Console.ReadLine();

            var results = VotingConsoleInputHandler.Handle(inputString);
            
            Console.WriteLine(results);
        }
        
        // ReSharper disable once FunctionNeverReturns
    }
}
