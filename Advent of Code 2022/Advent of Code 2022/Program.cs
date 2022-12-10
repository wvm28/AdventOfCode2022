using Advent_of_Code_2022.Days;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var interfaceType = typeof(IDay);
            var objects = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x));

            if (!objects.Any())
            {
                Console.WriteLine($"*************** No Code to run found ***************");
                Console.WriteLine($"Make sure your classes use the '{interfaceType.Name}' interface!");
            }

            bool run = true;

            while (run)
            {
                Console.WriteLine("Welcome to Advent of Code 2022");
                Console.Write("Which solution do you want to see?(1-" + objects.Count() + "): ");
                string? awnser = Console.ReadLine();
                try
                {
                    int number = int.Parse(awnser);
                    if (number <= objects.Count())
                    {
                        IDay instance = (IDay)objects.ElementAt(number - 1);

                        Console.WriteLine($"*************** Solutions Day {number} ***************");

                        Console.Write($"Solutions part one: ");
                        instance.partOne();


                        Console.Write($"Solutions part Two: ");
                        instance.partTwo();

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("That number is not one of the Advent of code days currently added to the solution, press anything to continue");
                        Console.Read();
                        Console.Clear();
                        continue;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not a number, press antyhing to continue");
                    Console.Read();
                    Console.Clear();
                    continue;
                }
            }



            /*int i = 1;
            foreach (IDay? instance in objects)
            {
                if (Object.ReferenceEquals(instance, null))
                    continue;

                Console.WriteLine($"*************** Solutions Day {i} ***************");

                Console.Write($"Solutions part one: ");
                instance.partOne();


                Console.Write($"Solutions part Two: ");
                instance.partTwo();

                Console.WriteLine();
                i++;
            }*/

            Console.ReadLine();
        }
    }
}