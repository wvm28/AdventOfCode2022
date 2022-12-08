namespace Advent_of_Code_2022.Days
{
    class Day08 : IDay
    {
        private List<List<Tree>> forest = new List<List<Tree>>();
        public Day08()
        {
            List<string> input = File.ReadAllLines(@"Days\Input\Day08.txt").ToList();
            List<Tree> previousRow = new List<Tree>();
            for (int i = 0; i < input.Count; i++)
            {
                List<Tree> currentRow = new List<Tree>();
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (previousRow.Count == 0)
                    {
                        if (j == 0)
                        {
                            currentRow.Add(new Tree(int.Parse(input[i][j].ToString()), null, null, null, null));
                        }
                        else
                        {
                            currentRow.Add(new Tree(int.Parse(input[i][j].ToString()), null, null, null, currentRow[j - 1]));
                            currentRow[j - 1].right = currentRow[j];
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            currentRow.Add(new Tree(int.Parse(input[i][j].ToString()), forest[i - 1][j], null, null, null));
                            forest[i - 1][j].down = currentRow[j];
                        }
                        else
                        {
                            currentRow.Add(new Tree(int.Parse(input[i][j].ToString()), forest[i - 1][j], null, null, currentRow[j - 1]));
                            forest[i - 1][j].down = currentRow[j];
                            currentRow[j - 1].right = currentRow[j];
                        }
                    }
                }
                forest.Add(currentRow);
                previousRow = currentRow;
            }
        }
        public void partOne()
        {
            int visibleTrees = 0;
            forest.ForEach(row =>
            {
                row.ForEach(tree =>
                {
                    if (tree.isVisible()) visibleTrees++;
                });
            });
            Console.WriteLine(visibleTrees);
        }

        public void partTwo()
        {
            int highestScore = 0;
            forest.ForEach(row =>
            {
                row.ForEach(tree =>
                {
                    if (tree.getSenicScore() > highestScore) highestScore = tree.getSenicScore();
                });
            });
            Console.WriteLine(highestScore);
        }
    }

    class Tree
    {
        public int heigth;
        public Tree? up;
        public Tree? right;
        public Tree? down;
        public Tree? left;
        public Tree(int heigth, Tree? up, Tree? right, Tree? down, Tree? left)
        {
            this.heigth = heigth;
            this.up = up;
            this.right = right;
            this.down = down;
            this.left = left;
        }

        public bool isVisible()
        {
            if (isVisibleUp() || isVisibleRight() || isVisibleDown() || isVisibleLeft()) return true; else return false;
        }

        public bool isVisibleUp()
        {
            Tree? next = this.up;
            bool visible = true;
            while (next != null)
            {
                if (next.heigth >= heigth) visible = false;
                next = next.up;
            }
            return visible;
        }

        public bool isVisibleRight()
        {
            Tree? next = this.right;
            bool visible = true;
            while (next != null)
            {
                if (next.heigth >= heigth) visible = false;
                next = next.right;
            }
            return visible;
        }

        public bool isVisibleDown()
        {
            Tree? next = this.down;
            bool visible = true;
            while (next != null)
            {
                if (next.heigth >= heigth) visible = false;
                next = next.down;
            }
            return visible;
        }

        public bool isVisibleLeft()
        {
            Tree? next = this.left;
            bool visible = true;
            while (next != null)
            {
                if (next.heigth >= heigth) visible = false;
                next = next.left;
            }
            return visible;
        }

        public int getSenicScore()
        {
            return getSenicScoreUp() * getSenicScoreRight() * getSenicScoreDown() * getSenicScoreLeft();
        }

        public int getSenicScoreUp()
        {
            int score = 0;
            Tree? next = this.up;
            while (next != null)
            {
                if (next.heigth < heigth) score++;
                if (next.heigth >= heigth)
                {
                    score++;
                    return score;
                }
                next = next.up;
            }
            return score;
        }

        public int getSenicScoreRight()
        {
            int score = 0;
            Tree? next = this.right;
            while (next != null)
            {
                if (next.heigth < heigth) score++;
                if (next.heigth >= heigth)
                {
                    score++;
                    return score;
                }
                next = next.right;
            }
            return score;
        }

        public int getSenicScoreDown()
        {
            int score = 0;
            Tree? next = this.down;
            while (next != null)
            {
                if (next.heigth < heigth) score++;
                if (next.heigth >= heigth)
                {
                    score++;
                    return score;
                }
                next = next.down;
            }
            return score;
        }

        public int getSenicScoreLeft()
        {
            int score = 0;
            Tree? next = this.left;
            while (next != null)
            {
                if (next.heigth < heigth) score++;
                if (next.heigth >= heigth)
                {
                    score++;
                    return score;
                }
                next = next.left;
            }
            return score;
        }
    }
}
