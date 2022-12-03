using Advent_of_Code_2022.Days;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Day01 day01 = new Day01();
            Console.WriteLine("*******Day 1 solution*******");
            day01.partOne();
            day01.partTwo();
            Console.WriteLine("----------------------------");

            Day02 day02 = new Day02();
            Console.WriteLine("*******Day 2 solution*******");
            day02.partOne();
            day02.partTwo();
            Console.WriteLine("----------------------------");

            Day03 day03 = new Day03();
            Console.WriteLine("*******Day 3 solution*******");
            day03.partOne();
            day03.partTwo();
            Console.WriteLine("----------------------------");

            Console.ReadLine();
        }
    }
}