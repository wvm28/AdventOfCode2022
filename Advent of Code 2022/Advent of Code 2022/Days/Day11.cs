namespace Advent_of_Code_2022.Days
{
    class Day11 : IDay
    {
        private List<Monkey> _monkeyList = new List<Monkey>();

        private void setUpMonkeyList()
        {
            _monkeyList.Clear();
            List<string> input = File.ReadAllLines(@"Days\Input\Day11.txt").ToList();
            input.Add("");
            List<List<string>> monkeys = new List<List<string>>();
            List<string> currentMonkey = new List<string>();
            input.ForEach(row =>
            {
                if (row == "" || row == null)
                {
                    monkeys.Add(currentMonkey);
                    currentMonkey = new List<string>();
                }
                else
                {
                    currentMonkey.Add(row);
                }
            });
            monkeys.ForEach(monkey =>
            {
                var itemsStrings = monkey[1].Split(" ").ToList();
                Queue<ulong> items = new Queue<ulong>();
                for (int i = 4; i < itemsStrings.Count; i++)
                {
                    var item = ulong.Parse(itemsStrings[i].Replace(",", string.Empty));
                    items.Enqueue(item);
                }
                List<string> operationStrings = monkey[2].Split(" ").ToList();
                List<string> testStrings = monkey[3].Split(" ").ToList();

                if (operationStrings[7] == "old")
                {
                    _monkeyList.Add(new Monkey(items, operationStrings[6], null, ulong.Parse(testStrings[5])));
                }
                else
                {
                    _monkeyList.Add(new Monkey(items, operationStrings[6], ulong.Parse(operationStrings[7]), ulong.Parse(testStrings[5])));
                }

            });

            for (int i = 0; i < _monkeyList.Count; i++)
            {
                _monkeyList[i].trueMonkey = _monkeyList[int.Parse(monkeys[i][4].Split(" ").ToList()[9])];
                _monkeyList[i].falseMonkey = _monkeyList[int.Parse(monkeys[i][5].Split(" ").ToList()[9])];

            }
        }

        public void partOne()
        {
            setUpMonkeyList();
            for (int i = 0; i < 20; i++)
            {
                _monkeyList.ForEach(monkey =>
                {
                    monkey.Act();
                });
            }

            List<int> monkeyBusiness = new List<int>();
            _monkeyList.ForEach(monkey =>
            {
                monkeyBusiness.Add(monkey.monkeyBusiness);
            });
            monkeyBusiness.Sort((x, y) => y.CompareTo(x));
            Console.WriteLine((monkeyBusiness[0] * monkeyBusiness[1]));
        }

        public void partTwo()
        {
            setUpMonkeyList();
            for (int i = 0; i < 10000; i++)
            {
                _monkeyList.ForEach(monkey =>
                {
                    monkey.Act2();
                });
            }


            List<int> monkeyBusiness = new List<int>();
            _monkeyList.ForEach(monkey =>
            {
                monkeyBusiness.Add(monkey.monkeyBusiness);
            });
            monkeyBusiness.Sort((x, y) => y.CompareTo(x));
            Console.WriteLine((monkeyBusiness[0] * monkeyBusiness[1]));
        }
    }

    class Monkey
    {
        public Queue<ulong> Items = new Queue<ulong>();

        public int monkeyBusiness = 0;

        private string operation;

        private ulong? _operationAmount;

        private ulong _testAmount;

        public Monkey? trueMonkey;

        public Monkey? falseMonkey;

        public Monkey(Queue<ulong> items, string operation, ulong? operationAmount, ulong testAmount)
        {
            Items = items;
            this.operation = operation;
            _operationAmount = operationAmount;
            _testAmount = testAmount;
        }

        public void Act()
        {
            while (Items.Count > 0)
            {
                ulong item = Items.Dequeue();
                switch (operation)
                {
                    case "+":
                        item = (ulong)(item + _operationAmount);
                        break;
                    case "*":
                        if (_operationAmount == null)
                        {
                            item = item * item;
                        }
                        else
                        {
                            item = (ulong)(item * _operationAmount);
                        }
                        break;
                }

                item = item / 3;

                if (item % _testAmount == 0)
                {
                    trueMonkey.Items.Enqueue(item);
                }
                else
                {
                    falseMonkey.Items.Enqueue(item);
                }
                monkeyBusiness++;
            }
        }

        public void Act2()
        {
            while (Items.Count > 0)
            {
                ulong item = Items.Dequeue();
                switch (operation)
                {
                    case "+":
                        item = (ulong)(item + _operationAmount);
                        break;
                    case "*":
                        if (_operationAmount == null)
                        {
                            item = item * item;
                        }
                        else
                        {
                            item = (ulong)(item * _operationAmount);
                        }
                        break;
                }

                if (item % _testAmount == 0)
                {
                    trueMonkey.Items.Enqueue(item);
                }
                else
                {
                    falseMonkey.Items.Enqueue(item);
                }
                monkeyBusiness++;
            }
        }
    }
}
