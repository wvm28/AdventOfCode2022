namespace Advent_of_Code_2022.Days
{
    class Day04
    {
        private List<int[][]> _elvenPairs = new List<int[][]>();


        public Day04()
        {
            List<string> input = File.ReadAllLines(@"Days\Input\Day04.txt").ToList();
            input.ForEach(i =>
            {
                string[] inputpairs = i.Split(',');
                int[] pair1 = new int[2];
                int[] pair2 = new int[2];
                foreach (var pair in inputpairs)
                {
                    string[] sections = pair.Split('-');
                    if (pair1[0] == 0)
                    {
                        pair1[0] = int.Parse(sections[0]);
                        pair1[1] = int.Parse(sections[1]);
                    }
                    else
                    {
                        pair2[0] = int.Parse(sections[0]);
                        pair2[1] = int.Parse(sections[1]);
                    }
                }
                int[][] pairs = new int[2][];
                pairs[0] = pair1;
                pairs[1] = pair2;
                _elvenPairs.Add(pairs);
                Console.WriteLine(pairs[0][0] + " - " + pairs[0][1] + " --- " + pairs[1][0] + " - " + pairs[1][1]);
            });

        }

        public void partOne()
        {
            var containedPairs = 0;
            _elvenPairs.ForEach(pair =>
            {
                if (pair[0][0] <= pair[1][0] && pair[0][1] >= pair[1][1] || pair[0][0] >= pair[1][0] && pair[0][1] <= pair[1][1]) containedPairs++;
            });
            Console.WriteLine(containedPairs);
        }

        public void partTwo()
        {
            var overlappingPairs = 0;
            _elvenPairs.ForEach(pair =>
            {
                if (pair[0][0] >= pair[1][0] && pair[0][0] <= pair[1][1] || pair[0][0] <= pair[1][0] && pair[0][1] >= pair[1][0]) overlappingPairs++;
            });
            Console.WriteLine(overlappingPairs);
        }
    }
}
