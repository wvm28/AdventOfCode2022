namespace Advent_of_Code_2022.Days
{
    class Day03
    {
        private List<string> _backpacks = new List<string>();

        private string _score = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Day03()
        {
            _backpacks = File.ReadAllLines(@"Days\Input\Day03.txt").ToList();
        }

        public void partOne()
        {
            var score = 0;
            _backpacks.ForEach(b =>
            {
                var firstComponent = b.Substring(0, (b.Length / 2));
                var secondComponent = b.Substring((b.Length / 2), (b.Length / 2));
                foreach (var l in firstComponent)
                {
                    if (secondComponent.Contains(l))
                    {
                        score += (_score.IndexOf(l) + 1);
                        break;
                    }
                }
            });
            Console.WriteLine(score);
        }

        public void partTwo()
        {
            var i = 0;
            var index = 0;
            var score = 0;
            _backpacks.ForEach(b =>
            {
                if (i == 0)
                {
                    foreach (var l in b)
                    {
                        if (_backpacks[index + 1].Contains(l) && _backpacks[index + 2].Contains(l))
                        {
                            score += (_score.IndexOf(l) + 1);
                            break;
                        }
                    }
                }
                i += 1;
                index += 1;
                if (i == 3) i = 0;
            });

            Console.WriteLine(score);
        }
    }
}
