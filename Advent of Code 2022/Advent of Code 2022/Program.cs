using Advent_of_Code_2022.Days;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1 day1 = new Day1();
            Console.WriteLine("*******Day 1 solution*******");
            day1.partOne();
            day1.partTwo();
            Console.WriteLine("----------------------------");

            Day2 day2 = new Day2();
            Console.WriteLine("*******Day 2 solution*******");
            day2.partOne();
            day2.partTwo();
            Console.WriteLine("----------------------------");

            Console.ReadLine();
        }
    }
}