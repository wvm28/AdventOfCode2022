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


            int i = 1;
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
            }

            Console.ReadLine();
        }
    }
}