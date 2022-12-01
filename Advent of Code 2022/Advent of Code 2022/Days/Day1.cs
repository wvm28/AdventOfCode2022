namespace Advent_of_Code_2022.Days
{
    class Day1
    {
        private string _inputFilePath = Path.Combine(Environment.CurrentDirectory + @"\..\..\..\Days\Input\Day1.txt");
        private List<int> _calories = new List<int>();
        public Day1()
        {
            foreach (string line in System.IO.File.ReadLines(_inputFilePath))
            {
                if (String.IsNullOrEmpty(line))
                {
                    _calories.Add(0);
                }
                else
                {
                    _calories.Add(Int32.Parse(line));
                }
            }
            _calories.Add(0);
        }
        public void partOne()
        {
            int currentElfCalories = new int();
            int highestCalories = new int();

            _calories.ForEach(i =>
            {
                if (i == 0)
                {
                    if (currentElfCalories > highestCalories)
                    {
                        highestCalories = currentElfCalories;
                    }
                    currentElfCalories = 0;
                }
                else
                {
                    currentElfCalories += i;
                }
            });

            Console.WriteLine("The awnser to part 1 of day 1 = " + highestCalories);
        }

        public void partTwo()
        {
            int currentElfCalories = new int();
            List<int> elfCalories = new List<int>();

            _calories.ForEach(i =>
            {
                if (i == 0)
                {
                    elfCalories.Add(currentElfCalories);
                    currentElfCalories = 0;
                }
                else
                {
                    currentElfCalories += i;
                }
            });

            elfCalories.Sort((x, y) => y.CompareTo(x));

            int combinedCalories = elfCalories[0] + elfCalories[1] + elfCalories[2];
            Console.WriteLine("The awnser to part 2 of day 1 = " + combinedCalories);
        }
    }
}
