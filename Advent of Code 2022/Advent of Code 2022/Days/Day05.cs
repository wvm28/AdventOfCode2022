namespace Advent_of_Code_2022.Days
{
    class Day05 : IDay
    {

        private List<Stack<char>> _crateStacks = new List<Stack<char>>();
        private List<string> _instructions = new List<string>();

        public Day05()
        {
            List<string> input = File.ReadAllLines(@"Days\Input\Day05.txt").ToList();
            bool isCrates = true;

            input.ForEach(line =>
            {
                if (isCrates)
                {
                    if (line == null || line == "") isCrates = false;
                }
                else
                {
                    _instructions.Add(line);
                }

            });
            _crateStacks.ForEach(stack =>
            {
                Console.Write("Stack something: ");
                foreach (var item in stack)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            });
        }

        public void partOne()
        {
            setUpCrates();

            _instructions.ForEach(instruction =>
            {
                var instrElements = instruction.Split(' ').ToList();
                moveCrates(int.Parse(instrElements[1].ToString()), int.Parse(instrElements[3].ToString()), int.Parse(instrElements[5].ToString()));
            });

            _crateStacks.ForEach(stack =>
            {
                Console.Write(stack.Peek());
            });
            Console.WriteLine();
        }

        public void partTwo()
        {
            setUpCrates();

            _instructions.ForEach(instruction =>
            {
                var instrElements = instruction.Split(' ').ToList();
                moveCratesTwo(int.Parse(instrElements[1].ToString()), int.Parse(instrElements[3].ToString()), int.Parse(instrElements[5].ToString()));
            });

            _crateStacks.ForEach(stack =>
            {
                Console.Write(stack.Peek());
            });
            Console.WriteLine();
        }

        private void moveCrates(int amount, int origin, int destination)
        {
            for (int i = 0; i < amount; i++)
            {
                if (_crateStacks[(origin - 1)].Count != 0) _crateStacks[(destination - 1)].Push(_crateStacks[(origin - 1)].Pop());
            }
        }

        private void moveCratesTwo(int amount, int origin, int destination)
        {
            Stack<char> crane = new Stack<char>();
            for (int i = 0; i < amount; i++)
            {
                if (_crateStacks[(origin - 1)].Count != 0) crane.Push(_crateStacks[(origin - 1)].Pop());
            }
            foreach (char crate in crane)
            {
                _crateStacks[(destination - 1)].Push(crate);
            }
        }

        private void setUpCrates()
        {
            _crateStacks.Clear();
            _crateStacks.Add(new Stack<char>(new char[] { 'T', 'D', 'W', 'Z', 'V', 'P' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'L', 'S', 'W', 'V', 'F', 'J', 'D' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'Z', 'M', 'L', 'S', 'V', 'T', 'B', 'H' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'R', 'S', 'J' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'C', 'Z', 'B', 'G', 'F', 'M', 'L', 'W' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'Q', 'W', 'V', 'H', 'Z', 'R', 'G', 'B' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'V', 'J', 'P', 'C', 'B', 'D', 'N' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'P', 'T', 'B', 'Q' }));
            _crateStacks.Add(new Stack<char>(new char[] { 'H', 'G', 'Z', 'R', 'C' }));
        }
    }
}
