namespace Advent_of_Code_2022.Days
{
    class Day2
    {
        private List<string[]> _rounds = new List<string[]>();
        public Day2()
        {
            foreach (string line in File.ReadAllLines(@"Days\Input\Day2.txt").ToList())
            {
                _rounds.Add(line.Split(null));
            }
        }

        public void partOne()
        {
            int totalScore = new int();
            _rounds.ForEach(r =>
            {
                switch (r[1])
                {
                    case "X":
                        totalScore += 1;
                        switch (r[0])
                        {
                            case "A":
                                totalScore += 3;
                                break;
                            case "C":
                                totalScore += 6;
                                break;
                        }
                        break;
                    case "Y":
                        totalScore += 2;
                        switch (r[0])
                        {
                            case "B":
                                totalScore += 3;
                                break;
                            case "A":
                                totalScore += 6;
                                break;
                        }
                        break;
                    case "Z":
                        totalScore += 3;
                        switch (r[0])
                        {
                            case "C":
                                totalScore += 3;
                                break;
                            case "B":
                                totalScore += 6;
                                break;
                        }
                        break;
                }
            });
            Console.WriteLine(totalScore);
        }

        public void partTwo()
        {
            int totalScore = new int();
            _rounds.ForEach(r =>
            {
                switch (r[1])
                {
                    case "X":
                        switch (r[0])
                        {
                            case "A":
                                totalScore += 3;
                                break;
                            case "B":
                                totalScore += 1;
                                break;
                            case "C":
                                totalScore += 2;
                                break;
                        }
                        break;
                    case "Y":
                        switch (r[0])
                        {
                            case "A":
                                totalScore += 4;
                                break;
                            case "B":
                                totalScore += 5;
                                break;
                            case "C":
                                totalScore += 6;
                                break;
                        }
                        break;
                    case "Z":
                        switch (r[0])
                        {
                            case "A":
                                totalScore += 8;
                                break;
                            case "B":
                                totalScore += 9;
                                break;
                            case "C":
                                totalScore += 7;
                                break;
                        }
                        break;
                }
            });
            Console.WriteLine(totalScore);
        }
    }
}
