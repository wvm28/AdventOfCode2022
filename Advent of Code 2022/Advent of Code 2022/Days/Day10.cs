namespace Advent_of_Code_2022.Days
{
    class Day10 : IDay
    {
        private List<elfCycle> _elfCycles = new List<elfCycle>();

        public Day10()
        {
            List<string> instructions = File.ReadAllLines(@"Days\Input\Day10.txt").ToList();
            int cycle = 1;
            int x = 1;

            instructions.ForEach(instruction =>
            {
                var instructionElements = instruction.Split(' ').ToList();
                switch (instructionElements[0])
                {
                    case "noop":
                        _elfCycles.Add(new elfCycle(cycle, x));
                        cycle++;
                        break;
                    case "addx":
                        _elfCycles.Add(new elfCycle(cycle, x));
                        cycle++;
                        _elfCycles.Add(new elfCycle(cycle, x));
                        cycle++;
                        x += int.Parse(instructionElements[1]);
                        break;
                }

            });

        }

        public void partOne()
        {
            Console.WriteLine(getSumSignalStrenghtFromCycles(new int[] { 20, 60, 100, 140, 180, 220 }));
        }

        public void partTwo()
        {
            Console.WriteLine();
            int i = 0;
            _elfCycles.ForEach(cycle =>
            {
                int consoleLocation = (cycle.cycle - 1) % 40;
                if (consoleLocation >= cycle.x - 1 && consoleLocation <= cycle.x + 1) Console.Write("█"); else Console.Write(" ");
                i++;
                if (i == 40)
                {
                    i = 0;
                    Console.WriteLine();
                }
            });
        }

        public int getSumSignalStrenghtFromCycles(int[] cycles)
        {
            int sum = 0;
            for (int i = 0; i < cycles.Length; i++)
            {
                sum += _elfCycles[cycles[i] - 1].cycle * _elfCycles[cycles[i] - 1].x;
            }
            return sum;
        }
    }

    class elfCycle
    {
        public int cycle;
        public int x;

        public elfCycle(int cycle, int x)
        {
            this.cycle = cycle;
            this.x = x;
        }
    }
}
