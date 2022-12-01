namespace Advent_of_Code_2022.Days
{
    class Day1
    {
        List<int> elfCalories = new List<int>();

        public Day1()
        {
            List<int> _calories = new List<int>();
            foreach (string line in File.ReadAllLines(@"Days\Input\Day1.txt").ToList())
            {
                if (String.IsNullOrEmpty(line)) _calories.Add(0); else _calories.Add(int.Parse(line));
            }
            _calories.Add(0);

            int currentElfCalories = new int();
            _calories.ForEach(i =>
            {
                if (i == 0) { elfCalories.Add(currentElfCalories); currentElfCalories = 0; } else currentElfCalories += i;
            });

            elfCalories.Sort((x, y) => y.CompareTo(x));
        }

        public void partOne()
        {
            Console.WriteLine("The awnser to part 1 of day 1 = " + elfCalories[0]);
        }

        public void partTwo()
        {
            int combinedCalories = elfCalories[0] + elfCalories[1] + elfCalories[2];
            Console.WriteLine("The awnser to part 2 of day 1 = " + combinedCalories);
        }
    }
}
