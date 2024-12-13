using AdventOfCode.Day13;
using System.Text.RegularExpressions;

public static class Day13
{
    public static void Execute()
    {
        string filePath = "Day13/Test.txt";
        var regex = new Regex(@"[A-Za-z ]{5,8}: X[+=]([0-9]{1,7}), Y[+=]([0-9]{1,7})");
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var machines = new List<Machine>();
            for ( int i = 0; i < lines.Length; i=i+4)
            {
                var machine = new Machine();
                var matchLine1 = regex.Match(lines[i]);
                machine.ButtonA.X = Int64.Parse(matchLine1.Groups[1].Value);
                machine.ButtonA.Y = Int64.Parse(matchLine1.Groups[2].Value);
                var matchLine2 = regex.Match(lines[i + 1]);
                machine.ButtonB.X = Int64.Parse(matchLine2.Groups[1].Value);
                machine.ButtonB.Y = Int64.Parse(matchLine2.Groups[2].Value);
                var matchLine3 = regex.Match(lines[i + 2]);
                machine.Prize.X = Int64.Parse(matchLine3.Groups[1].Value);
                machine.Prize.Y = Int64.Parse(matchLine3.Groups[2].Value);
                machines.Add(machine);
            }
            Console.WriteLine($"{machines.Count} machines");

            Int64 tokensSpent = 0;
            foreach (var machine in machines)
            {
                var maxPressesX = machine.Prize.X / Math.Min(machine.ButtonA.X, machine.ButtonB.X);
                var maxPressesY = machine.Prize.Y / Math.Min(machine.ButtonA.Y, machine.ButtonB.Y);
                var maxPresses = Math.Max(maxPressesX, maxPressesY);
                var games = new List<Game>();
                for (int i = 0; i < maxPresses; i++)
                {
                    var game = new Game();
                    game.NumberOfPressesA = i;
                    for (int j = 0; j < maxPresses - i; j++)
                    {
                        game.NumberOfPressesB = j;
                        var totalX = game.NumberOfPressesA * machine.ButtonA.X + game.NumberOfPressesB * machine.ButtonB.X;
                        var totalY = game.NumberOfPressesA * machine.ButtonA.Y + game.NumberOfPressesB * machine.ButtonB.Y;
                        if (totalX == machine.Prize.X && totalY == machine.Prize.Y)
                        {
                            game.IsSuccess = true;
                            game.TotalCost = 3 * game.NumberOfPressesA + game.NumberOfPressesB;
                            games.Add(game);
                            break;
                        }
                    }
                }
                var winningGame = games.Where(g => g.IsSuccess).OrderBy(g => g.TotalCost).FirstOrDefault();
                if (winningGame != null)
                {
                    Console.WriteLine($"Machine at {machine.ButtonA.X},{machine.ButtonA.Y} and {machine.ButtonB.X},{machine.ButtonB.Y} can win the prize at {machine.Prize.X},{machine.Prize.Y} with {winningGame.NumberOfPressesA} presses of button A and {winningGame.NumberOfPressesB} presses of button B at a cost of {winningGame.TotalCost}");
                    tokensSpent += winningGame.TotalCost;
                }
                else
                {
                    Console.WriteLine($"Machine at {machine.ButtonA.X},{machine.ButtonA.Y} and {machine.ButtonB.X},{machine.ButtonB.Y} cannot win the prize at {machine.Prize.X},{machine.Prize.Y}");
                }
            }
            Console.WriteLine($"Tokens spent: {tokensSpent}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
   
}