namespace Advent_of_Code_2022.Days
{
    class Day01 : IDay
    {
        private List<int> _elfCalories = new List<int>();

        public Day01()
        {
            List<int> calories = new List<int>();
            foreach (string line in File.ReadAllLines(@"Days\Input\Day01.txt").ToList())
            {
                if (String.IsNullOrEmpty(line)) calories.Add(0); else calories.Add(int.Parse(line));
            }
            calories.Add(0);

            int currentElfCalories = new int();
            calories.ForEach(i =>
            {
                if (i == 0) { _elfCalories.Add(currentElfCalories); currentElfCalories = 0; } else currentElfCalories += i;
            });

            _elfCalories.Sort((x, y) => y.CompareTo(x));
        }

        public void partOne()
        {
            Console.WriteLine(_elfCalories[0]);
        }

        public void partTwo()
        {
            int combinedCalories = _elfCalories[0] + _elfCalories[1] + _elfCalories[2];
            Console.WriteLine(combinedCalories);
        }
    }
}
