namespace Advent_Of_Code_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elfCount = 0;
            bool collectingData = true;
            List<int> elves = new();

            int highestResult = 0;
            int elfWithMostCals = 0;

            while (collectingData)
            {
                elfCount++;
                int thisElfCalories = 0;
                bool thisElfIsDone = false;

                while (!thisElfIsDone)
                {
                    // this looks like manual input, but it works to just copy-paste
                    // the entire file contents into the console window
                    string input = GetInput(elfCount, thisElfCalories);
                    if (input == "")
                    {
                        thisElfIsDone = true;
                    }

                    if (input == "break")
                    {
                        collectingData = false;
                        thisElfIsDone = true;
                    }

                    _ = int.TryParse(input, out int calories);
                    thisElfCalories += calories;
                }
                
                elves.Add(thisElfCalories);
                if (thisElfCalories > highestResult)
                {
                    highestResult = thisElfCalories;
                    elfWithMostCals = elves.Count;
                }
            }

            Console.WriteLine($"Elf #{elfWithMostCals} has the highest calories: {highestResult}.");
            int sumOfTopThree = elves.OrderByDescending(x => x).Take(3).Sum();
            Console.WriteLine($"Sum of top 3: {sumOfTopThree}");
        }

        static string GetInput(int elfNumber, int runningTotal)
        {
            bool validResult = false;
            string? input = null;
            while (!validResult)
            {
                Console.WriteLine($"Currently logging for elf #{elfNumber}, running total {runningTotal}:");
                input = Console.ReadLine();
                if (input != null)
                {
                    validResult = true;
                }
            }

            return input!;
        }
    }
}