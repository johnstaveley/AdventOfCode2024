using AdventOfCode.Day17;
using System.Text.RegularExpressions;

public static class Day17
{
    public static void Execute()
    {
        string filePath = "Day17/test.txt";
        Regex registerRegex = new Regex(@"Register [A-C]{1}: ([0-9]{1,6})");
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var matchA = registerRegex.Match(lines[0]);
            var matchB = registerRegex.Match(lines[1]);
            var matchC = registerRegex.Match(lines[2]);
            int registerA = int.Parse(matchA.Groups[1].Value);
            int registerB = int.Parse(matchB.Groups[1].Value);
            int registerC = int.Parse(matchC.Groups[1].Value);
            Console.WriteLine($"Initial values: A={registerA}, B={registerB}, C={registerC}");
            List<int> values = lines[4].Replace("Program: ", "").Split(",").Select(a => int.Parse(a)).ToList();
            List<Instruction> program = new List<Instruction>();
            for (int i = 0; i < values.Count; i += 2)
            {
                var instruction = new Instruction(values[i], values[i + 1]);
                program.Add(instruction);
                Console.WriteLine($"OpCode: {instruction.OpCode}, Operand: {instruction.Operand}, Operation: {instruction.Operation}");
                switch (instruction.Operation)
                {
                    case "adv":
                        registerA = (int) (instruction.Operand / instruction.GetCombo(registerA, registerB, registerC));
                        break;
                    case "bxl":
                        registerB =  registerB ^ instruction.Operand;
                        break;

                }
            }
            Console.WriteLine($"Program has {program.Count()} instructions");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

}