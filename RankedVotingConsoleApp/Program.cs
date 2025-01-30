using RankedVotingConsoleApp.VotingConsole;

namespace RankedVotingConsoleApp
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            InitVotingConsole();
        }

        private static void InitVotingConsole()
        {
            VotingTerminal.StartPrompt();
        }
    }
}