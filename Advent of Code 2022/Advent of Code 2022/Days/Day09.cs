namespace Advent_of_Code_2022.Days
{
    class Day09 : IDay
    {
        private List<string> _moves;

        public Day09()
        {
            _moves = File.ReadAllLines(@"Days\Input\Day09.txt").ToList();

        }
        public void partOne()
        {
            HashSet<int[]> positions = new HashSet<int[]>();
            int triggers = 0;
            int[] headLocation = new int[] { 0, 0 };
            int[] tailLocation = new int[] { 0, 0 };
            positions.Add(new int[] { 0, 0 });
            _moves.ForEach(move =>
            {
                string direction = move.Split(" ").ToList()[0];
                int amount = int.Parse(move.Split(" ").ToList()[1]);
                for (int i = 0; i < amount; i++)
                {
                    int[] old = new int[] { headLocation[0], headLocation[1] };
                    switch (direction)
                    {
                        case ("U"):
                            headLocation[1]++;
                            break;
                        case ("R"):
                            headLocation[0]++;
                            break;
                        case ("D"):
                            headLocation[1]--;
                            break;
                        case ("L"):
                            headLocation[0]--;
                            break;
                    }

                    int x = Math.Abs(tailLocation[0] - headLocation[0]);
                    int y = Math.Abs(tailLocation[1] - headLocation[1]);
                    if (x > 1 || y > 1)
                    {
                        tailLocation[0] = old[0];
                        tailLocation[1] = old[1];
                        if (!positions.Any(p => p.SequenceEqual(new int[] { tailLocation[0], tailLocation[1] }))) positions.Add(new int[] { tailLocation[0], tailLocation[1] });
                        triggers++;
                    }
                }
            });
            Console.WriteLine(positions.Count);
        }

        public void partTwo()
        {
            HashSet<int[]> positions = new HashSet<int[]>();
            int triggers = 0;
            List<int[]> ropePieces = new List<int[]>();
            for (int i = 0; i < 10; i++)
            {
                ropePieces.Add(new int[] { 0, 0 });
            }
            positions.Add(new int[] { 0, 0 });
            _moves.ForEach(move =>
            {
                string direction = move.Split(" ").ToList()[0];
                int amount = int.Parse(move.Split(" ").ToList()[1]);

                for (int i = 0; i < amount; i++)
                {
                    switch (direction)
                    {
                        case ("U"):
                            ropePieces[0][1]++;
                            break;
                        case ("R"):
                            ropePieces[0][0]++;
                            break;
                        case ("D"):
                            ropePieces[0][1]--;
                            break;
                        case ("L"):
                            ropePieces[0][0]--;
                            break;
                    }

                    for (int j = 1; j < ropePieces.Count; j++)
                    {
                        ropePieces[j] = updatePiece(ropePieces[j - 1], ropePieces[j]);
                        if (!positions.Any(p => p.SequenceEqual(new int[] { ropePieces[j][0], ropePieces[j][1] })) && j == 9)
                        {
                            positions.Add(new int[] { ropePieces[j][0], ropePieces[j][1] });
                            triggers++;
                        }
                    }


                }
            });
            Console.WriteLine(positions.Count);
        }

        private int[] updatePiece(int[] head, int[] tail)
        {
            int diffX = head[0] - tail[0];
            int diffY = head[1] - tail[1];
            int deltaX = 0;
            int deltaY = 0;
            if (Math.Abs(diffX) > 1 || Math.Abs(diffY) > 1)
            {
                deltaX = Math.Sign(diffX);
                deltaY = Math.Sign(diffY);
            }
            return new int[] { tail[0] + deltaX, tail[1] + deltaY };
        }
    }
}
