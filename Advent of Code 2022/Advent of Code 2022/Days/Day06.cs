namespace Advent_of_Code_2022.Days
{
    class Day06 : IDay
    {
        private string _dataStream = "";
        public Day06()
        {
            _dataStream = File.ReadLines(@"Days\Input\Day06.txt").ToList()[0];
        }

        public void partOne()
        {
            Console.WriteLine(getLastIndexWithoutDuplicates(3));
        }

        public void partTwo()
        {
            Console.WriteLine(getLastIndexWithoutDuplicates(13));
        }

        public int getLastIndexWithoutDuplicates(int amount)
        {
            Queue<char> previousChars = new Queue<char>();
            int firstMarkerStart = 0;
            for (int i = 0; i < _dataStream.Length; i++)
            {
                if (i < amount)
                {
                    previousChars.Enqueue(_dataStream[i]);
                }
                else
                {
                    previousChars.Enqueue(_dataStream[i]);
                    if (!previousChars.GroupBy(value => value).Any(@group => @group.Count() > 1))
                    {
                        if (firstMarkerStart == 0) firstMarkerStart = (i + 1);
                    };
                    previousChars.Dequeue();
                }
            }
            return firstMarkerStart;
        }
    }
}
